using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridRandomizer : MonoBehaviour
{
    public int[] newLine;
    public int maxTileValue;
    static int seed;
    public int[,] mapValues = new int[17, 11];
    public int[,] tempMapValues;
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
        for (int i = 0; i < 17; ++i)
        {
            for (int j = 0; j < 11; ++j)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        mapValues[i, j] = (Random.Range(1,10) - Random.Range(1,10));
                        break;
                    case 1:
                        mapValues[i, j] = (Random.Range(1, 10) + Random.Range(1, 10));
                        break;
                    case 2:
                        mapValues[i, j] = (Random.Range(1, 10) * Random.Range(1, 10));
                        break;
                }
            }
        }
        return mapValues;   
    }
    public int[] lineRandomizer()
    {
        newLine = new int[17];
        for (int i = 0; i < 17; ++i)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    newLine[i] = (Random.Range(1, 10) - Random.Range(1, 10));
                    break;
                case 1:
                    newLine[i] = (Random.Range(1, 10) + Random.Range(1, 10));
                    break;
                case 2:
                    newLine[i] = (Random.Range(1, 10) * Random.Range(1, 10));
                    break;
            }
        }
        return newLine;
    }
}
