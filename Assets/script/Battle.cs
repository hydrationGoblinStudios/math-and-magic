using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Wipe;
    public ProjectileBehavior ProjectilePrefab;
    public Transform[] LineTransform;
    public Slot slot;
    public int current;
    public TextMeshPro[] LineTexts;
    public Material[] LineValues;
    public int[] RowNumbers = new int [3];
    public int rando;
    public int rando2;
    public int result;
    public int temp;
    public int temp2;
    public string text;

    void Update()
    {
        current = slot.result;
        while (LineValues[0].card.cardValue == LineValues[2].card.cardValue && LineValues[1].card.cardValue == LineValues[2].card.cardValue)
        {
            Debug.Log("fall guys");
            LineValues[2].card.cardCreator();
        }
        while (LineValues[3].card.cardValue == LineValues[4].card.cardValue)
        {
            Debug.Log("amogus");
            LineValues[4].card.cardCreator();
        }
        if (temp2 == 0){
            StartCoroutine(BattleStart());
            temp2 = 1;
        }
        if (RowNumbers[1] == RowNumbers[0])
        {
            LineRandomize(LineTexts[1]);
            RowNumbers[1] = int.Parse(LineTexts[1].text);
        }
        if(RowNumbers[2] == RowNumbers[1] || RowNumbers[2] == RowNumbers[0])
        {
            LineRandomize(LineTexts[2]);
            RowNumbers[2] = int.Parse(LineTexts[2].text);
        }
        if(current == int.Parse(LineTexts[0].text))
        {
            slot.result = 9999;
            send(0);
            slot.HandShuffle();
            StartCoroutine(BattleStart());
        }
        if (current == int.Parse(LineTexts[1].text))
        {
            slot.result = 9999;
            send(1);
            slot.HandShuffle();
            StartCoroutine(BattleStart());
        }
        if (current == int.Parse(LineTexts[2].text))
        {
            slot.result = 9999;
            send(2);
            slot.HandShuffle();
            StartCoroutine(BattleStart());
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(BattleStart());
        }
    }
    public void send(int x)
    {
        Instantiate(ProjectilePrefab, LineTransform[x].position,transform.rotation);
    }
    public void LineRandomize(TextMeshPro text2)
    {
        temp = LineValues[Random.Range(3,5)].cardvalue;
        temp = LineMaker(LineValues[Random.Range(3,5)].cardvalue);
        text2.text = "" + temp;

   }
    public int LineMaker(int line)
    {
        Debug.Log("linemaker");
        rando = Random.Range(0, 3);
        rando2 = Random.Range(0, 3);
        if (rando == rando2)
        {
            LineMaker(line);
        }
        else
        {
            switch (line)
            {
                case 0:
                    result = LineValues[rando].cardvalue - LineValues[rando2].cardvalue;

                    break;
                case 1:
                    result = LineValues[rando].cardvalue + LineValues[rando2].cardvalue;
                    break;
                case 2:
                    result = LineValues[rando].cardvalue * LineValues[rando2].cardvalue;
                    break;
                default:
                    break;
            }
        }
        Debug.Log(result);
        return result;
    }
    public IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    public IEnumerator BattleStart()
    {
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < LineTexts.Length; i++)
        {
            LineRandomize(LineTexts[i]);
            RowNumbers[i] = int.Parse(LineTexts[i].text);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    public IEnumerator DisingageInMagickerfuffles()
    {
        enemy.transform.position = new Vector2(120,120);
        Wipe.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.UnloadScene(2);
    }
}
