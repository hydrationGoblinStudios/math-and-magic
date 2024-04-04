using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridMaracutaia : MonoBehaviour
{
    public int[]tempLine;
    public GridRandomizer gridRandomizer;
    public GameObject tile;
    public int[,] mapValues;
    public int[,] tempMapValues;
    [SerializeField]
    private TextMeshPro[,] textMeshPro = new TextMeshPro [17,11];
    public float timer;
    public float timerMax;
    public PlayerController playerController;
    public TextMeshPro timerText;
    public void Start()
    {
        mapValues = GridRandomizer.Instance.Randomize();  
        //GridMaker();
        //TileWriter();
    }
    public void Awake()
    {
        timerMax = timer;
    }
    public void GridMaker()
    {for (int x = -7; x <= 8; x++)
        {
            for (int y = 5; y >= -5; y--)
            {
                GameObject instance =
                Instantiate(tile, transform);
                textMeshPro[x+7,y+5] = (instance.GetComponent<TextMeshPro>());
                instance.transform.position = new Vector3(x, y, 0);
            }
        }
    }
    public void TileWriter()
    {
        for(int x = 0; x <= 16; x++)
        {
            for(int y = 0; y <= 10; y++)
            {
                textMeshPro[x,y].text = ""+mapValues[x,y];
            }
        }
    }
    public void Update()
    {
        timerText.text = ""+(int)timer;
        if (playerController.pause == false)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = timerMax;
            moveDown();
        }
    }
    public void moveDown()
    {
        tempMapValues = mapValues;
        tempLine = gridRandomizer.lineRandomizer();
        
        for (int x = 0; x <= 16; x++)
        {
            for (int y = 0; y <= 9; y++)
            {
               mapValues[x,y] = tempMapValues[x,y+1];
            }
        }
        for (int x = 0; x <= 16; x++)
        {
            mapValues[x, 10] = tempLine[x];
        }
    }
}