using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{
    private int[] coreMatrix = {1,1,1,1,1,1,1,1};
    private int[] creatureMatrix;

    private void Awake()
    {
        setCreatureMatrix(coreMatrix);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            replicate();
            Debug.Log(creatureMatrix.ToCommaSeparatedString());
        }
    }

    public void replicate()
    {
        Vector3 position = gameObject.transform.position + Random.insideUnitSphere * 1;
        Species replicant = Instantiate(this, position, Quaternion.identity);

        replicant.setCreatureMatrix(evolveMatrix(coreMatrix, creatureMatrix));
        creatureMatrix = evolveMatrix(coreMatrix, creatureMatrix);
    }

    public void setCreatureMatrix(int[] p_creatureMatrix)
    {
        creatureMatrix = p_creatureMatrix;
    }

    /*
     * When a creature clones itself
     */
    private int[] evolveMatrix(int[] p_coreMatrix, int[] p_creatureMatrix)
    {
        int[] _evolvedMatrix = new int[p_coreMatrix.Length];
        int _evolvedValue = 0;

        for (var i = 0; i < p_coreMatrix.Length; i++)
        {
            if (p_coreMatrix[i] > 0 && p_creatureMatrix[i] > 0)
            {
                _evolvedValue = Random.Range(Mathf.Min(p_coreMatrix[i], p_creatureMatrix[i]), (p_coreMatrix[i] + p_creatureMatrix[i]+1)/2);
            }
            else
            {
                _evolvedValue = 0;
            }

            _evolvedMatrix[i] = _evolvedValue;
        }

        return _evolvedMatrix;
    }

    /*
     * When a creature mutates
     * 
     * TODO: change the logic. Currently it is the same as for cloning
     */
    private int[] mutateMatrix(int[] coreMatrix, int[] generationMatrix)
    {
        int[] _mutatedMatrix = new int[coreMatrix.Length];
        int _mutatedValue = 0;

        for (var i = 0; i < coreMatrix.Length; i++)
        {
            if (coreMatrix[i] > 0 && generationMatrix[i] > 0)
            {
                _mutatedValue = Random.Range(Mathf.Min(coreMatrix[i], generationMatrix[i]), (coreMatrix[i] + generationMatrix[i]) + 1);
            }
            else
            {
                _mutatedValue = 0;
            }

            _mutatedMatrix[i] = _mutatedValue;
        }

        return _mutatedMatrix;
    }

}
