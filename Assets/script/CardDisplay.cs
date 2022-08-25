using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public static CardDisplay Instance { get; private set; }
    [SerializeField]
    private TextMeshPro textMeshPro;
    public Card card;
    public int cardValue;
    void Start()
    {
        cardCreator();
    }
    public void cardCreator()
    {
        cardValue = card.CardRandomizer();
        if (card.type)
        {
            switch (cardValue)
            {
                case 0:
                    textMeshPro.text = "-";
                    break;
                case 1:
                    textMeshPro.text = "+";
                    break;
                case 2:
                    textMeshPro.text = "x";
                    break;
            }
        }
        else
        {
            textMeshPro.text = "" + cardValue;
        }
    }
}

