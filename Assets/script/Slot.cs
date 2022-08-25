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
    string[] equation = new string[3];
    public int result;
    string x;
    string y;
    public int index;
    public TextMeshPro resultText;
    public Transform closestSnapPoint;
    public bool full = false;

    private void Start()
    {
        closestSnapPoint = snapPoints[0];
        foreach (Material material in materialObjects)
        {
            cardSpawnPoint.Add(material.transform.position);
            material.dragEndedCallback = OnDragEnded;
        }
    }
    private void OnDragEnded(Material material, CardDisplay cardDisplay)
    {
        float closestDistance = -1;
        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(material.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }
        //checa se a carta esta no slot certo pra o tipo
        if (cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) == 1 && full == false || !cardDisplay.card.type & snapPoints.IndexOf(closestSnapPoint) != 1 && full == false) 
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
                    //faz a equacao baseado nas cartas nos slots
                    switch (equation[1])
                    {
                        case "0":
                            Debug.Log(int.Parse(x));
                            result = int.Parse(x) - int.Parse(y);
                            resultText.SetText($"{result}");
                            closestSnapPoint = snapPoints[0];
                            full = false;
                            Debug.Log(result);
                            break;
                        case "1":
                            result = int.Parse(x) + int.Parse(y);
                            resultText.SetText($"{result}");
                            closestSnapPoint = snapPoints[0];
                            full = false;
                            Debug.Log(result);
                            break;
                        case "2":
                            result = int.Parse(x) * int.Parse(y);
                            resultText.SetText($"{result}");
                            closestSnapPoint = snapPoints[0];
                            full = false;
                            Debug.Log(result);
                            break;
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
        equation = new string[3];
        result = 99;
        Debug.Log("clear");
        slottedCards.Clear();
    }
    private void CardShuffle()
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
            StartCoroutine("CardReset");
            CardShuffle();
            CardReset();
            closestSnapPoint = snapPoints[0];
        }
    }
}