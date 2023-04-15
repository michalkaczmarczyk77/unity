using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeciesSigleton : MonoBehaviour
{
    public static SpeciesSigleton Instance { get; private set; }
    public static int[] CoreMatrix = { 1,1,0,0,1,0,1,1};

    private void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }

    private int[] generateCoreMatrix(int matrixLength)
    {
        int[] _coreMatrix = new int[matrixLength];

        for (var i = 0; i < matrixLength; i++)
        {
            _coreMatrix[i] = UnityEngine.Random.Range(0, 2);
        }

        return _coreMatrix;
    }

}
