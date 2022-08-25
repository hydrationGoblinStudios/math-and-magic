using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridMaracutaia : MonoBehaviour
{
    string line;
    string tileMapValue = "";
    public int[,] mapValues;
    [SerializeField]
    private TextMeshPro textMeshPro;
    public void Start()
    {
        mapValues = GridRandomizer.Instance.Randomize();
        for (int i = 0; i < 11; ++i)
        {
            int[] chara = new int[16];
            for (int j = 0; j < 16; ++j)
            {
                chara[j] = mapValues[j, i];
            }
            line = string.Join("", chara);
            tileMapValue = line + tileMapValue;
        }
        textMeshPro.SetText($"<mspace=1.11em>{tileMapValue}");
    }
}