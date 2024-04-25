using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    public float snapRange;
    public CardDisplay cardDisplay;
    public List<Material> slottedCards;
    public List<Transform> snapPoints;
    public List<Material> materialObjects;
    public List<Vector2> cardSpawnPoint;
    string[] equation = new string[5];
    string[] equation2 = new string[3];
    public int result;
    string x,y,z;
    public int index;
    public TextMeshPro resultText;
    public Transform closestSnapPoint;
    public bool full = false;
    public PlayerBehavior player;
    public EnemyBehavior enemy;

    private void Start()
    {
        enemy = FindObjectOfType<EnemyBehavior>();
        closestSnapPoint = snapPoints[0];
        foreach (Material material in materialObjects)
        {
            cardSpawnPoint.Add(material.transform.position);
            material.dragEndedCallback = OnDragEnded;
        }
    }
    private void OnDragEnded(Material material, CardDisplay cardDisplay)
    {        
        //checa se a carta esta no slot certo pra o tipo
        if (cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) == 1 && full == false || !cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) != 1 && full == false || cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) == 3 && full == true|| !cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) != 3 && full == true) 
        {
            if (closestSnapPoint != null)
            {
                material.transform.localPosition = closestSnapPoint.localPosition;
                slottedCards.Add(material);
                equation[snapPoints.IndexOf(closestSnapPoint)] = "" + material.cardvalue;

                switch (snapPoints.IndexOf(closestSnapPoint))
                {
                    case 0:
                        closestSnapPoint = snapPoints[1];
                        break;
                    case 1:
                        closestSnapPoint = snapPoints[2];
                        break;
                    case 2:
                        equation2[0] = equation[0];
                        equation2[1] = equation2[1];
                        equation2[2] = equation2[2];
                        full = true;
                        if (snapPoints[3] != null)
                        {
                            closestSnapPoint = snapPoints[3];
                        }
                        else
                        {
                            closestSnapPoint = null;
                        }
                        full = true;
                        break;
                    case 3:
                        closestSnapPoint = snapPoints[4];
                        break;
                    case 4:
                        closestSnapPoint = null;
                        full = true;
                        break;
                    default:
                        break;
                }
                //checa se todos os slots estao cheios
                foreach (var item in equation.Where(n => n != null))
                {
                    x = equation[0];
                    y = equation[2];
                    z = equation[4];
                    //faz a equacao baseado nas cartas nos slots
                    switch (equation[1])
                    {
                        case "0":
                            switch (equation[3])
                            {
                                case "0":
                                    result = int.Parse(x) - int.Parse(y) - int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                                case "1":
                                    result = int.Parse(x) - int.Parse(y) + int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                                case "2":
                                    result = int.Parse(x) - int.Parse(y) * int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                            }
                            break;
                        case "1":
                            switch (equation[3])
                            {
                                case "0":
                                    result = int.Parse(x) + int.Parse(y) - int.Parse(z);
                                    resultText.SetText($"{result}");
                                    Debug.Log(result);
                                    break;
                                case "1":
                                    result = int.Parse(x) + int.Parse(y) + int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                                case "2":
                                    result = int.Parse(x) + int.Parse(y) * int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                            }
                            break;
                        case "2":
                            switch (equation[3])
                            {
                                case "0":
                                    Debug.Log(int.Parse(x));
                                    result = int.Parse(x) * int.Parse(y) - int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                                case "1":
                                    result = int.Parse(x) * int.Parse(y) + int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                                case "2":
                                    result = int.Parse(x) * int.Parse(y) * int.Parse(z);
                                    resultText.SetText($"{result}");
                                    break;
                            }
                            if (result % 2 == 0)
                            {
                                Debug.Log("numero par");
                                player.CallItemPar(enemy);


                            }
                            if (result % 2 == 1)
                            {
                                
                            }
                            break;
                    }
                }
                foreach (var item in equation2.Where(n => n != null ))
                {
                    x = equation[0];
                    y = equation[2];
                    //faz a equacao baseado nas cartas nos slots
                    if(equation[4] == null){
                        switch (equation[1])
                        {
                            case "0":
                                Debug.Log(int.Parse(x));
                                result = int.Parse(x) - int.Parse(y);
                                resultText.SetText($"{result}");
                                break;
                            case "1":
                                result = int.Parse(x) + int.Parse(y);
                                resultText.SetText($"{result}");
                                break;
                            case "2":
                                result = int.Parse(x) * int.Parse(y);
                                resultText.SetText($"{result}");
                                break;
                        } 
                    }
                }
            }           
        }       
    }
    public IEnumerator CardReset()
    {
        yield return new WaitForSeconds((float)0.3);
        foreach (Material x in slottedCards)
        {
            x.transform.position = cardSpawnPoint[materialObjects.IndexOf(x)];
            x.card.cardCreator();
        }
        full = false;
        equation = new string[5];
        equation2 = new string[3];
        result = 99;
        slottedCards.Clear();
    }
    public void CardShuffle()
    {
        foreach(Material x in materialObjects)
        {
            x.card.cardCreator();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            HandShuffle();
        }
    }
    public void HandShuffle()
    {
        StartCoroutine("CardReset");
        CardShuffle();
        closestSnapPoint = snapPoints[0];
    }
}