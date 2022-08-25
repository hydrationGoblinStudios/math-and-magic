using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRandomizer : MonoBehaviour
{
    public string bazinga2;
    static int seed;
    public int[,] mapValues = new int[17, 11];
    // Start is called before the first frame update
    public static GridRandomizer Instance { get; private set; }
    public void Awake()
    {
        seed = Random.Range(0, 9999);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public int[,] Randomize()
    {
        Random.seed = seed;
        for (int i = 0; i < 17; ++i)
        {
            for (int j = 0; j < 11; ++j)
            {
                mapValues[i, j] = Random.Range(1, 10);
            }
        }
        return mapValues;   
    }
}
