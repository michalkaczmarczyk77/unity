using Unity.VisualScripting;
using UnityEngine;

public class SpeciesCore : MonoBehaviour
{
    //private int matrixLength = 4;
    private int[] coreMatrix;  // species matrix. It does not change over the time
    private int[] beingMatrix; // current creature matrix. It evolves each time it is cloned or mutated

    private void Awake()
    {

        Debug.Log("Awaked");
        /*
           Debug.Log(beingMatrix.ToCommaSeparatedString());
        */
    }

    private void Start()
    {
        //beingMatrix = evolveMatrix(coreMatrix, coreMatrix);
    }

    private void Update()
    {
        coreMatrix = SpeciesSigleton.CoreMatrix;
        if (Input.GetMouseButtonDown(0))
        {
            clone();
            Debug.Log(coreMatrix.ToCommaSeparatedString());
        }
    }


    public void clone()
    {
        Vector3 position = gameObject.transform.position + Random.insideUnitSphere * 1;
        //Vector2 position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

        SpeciesCore clone = Instantiate(this, position, Quaternion.identity);
    }

    /*
     * TODO: Implement as STATIC method in the singleton SpeciesCoreController
     */
    public int[] generateCoreMatrix(int matrixLength)
    {
        int[] _coreMatrix = new int[matrixLength];

        for (var i = 0; i < matrixLength; i++)
        {
            _coreMatrix[i] = Random.Range(0, 2);
        }

        return _coreMatrix;
    }

    /*
     * When a creature clones itself
     */
    public int[] evolveMatrix(int[] p_coreMatrix, int[] p_generationMatrix)
    {
        int[] _evolvedMatrix = new int[p_coreMatrix.Length];
        int _evolvedValue =0;

        for (var i = 0; i < p_coreMatrix.Length; i++)
        {
            if (p_coreMatrix[i]>0 && p_generationMatrix[i] > 0)
            {
                _evolvedValue = Random.Range(Mathf.Min(coreMatrix[i], p_generationMatrix[i]), (p_coreMatrix[i]+ p_generationMatrix[i])+1);
            }else
            {
                _evolvedValue = 0;
            }

            _evolvedMatrix[i]= _evolvedValue;
        }

        return _evolvedMatrix;
    }

    /*
     * When a creature mutates
     * 
     * TODO: change the logic. Currently it is the same as for cloning
     */
    public int[] mutateMatrix(int[] coreMatrix, int[] generationMatrix)
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
