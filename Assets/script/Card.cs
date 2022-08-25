using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Card",menuName = "ScriptableObject/Card")]
public class Card : ScriptableObject
{
    public Sprite cardSprite;
    public int cardValue = 0;
    public bool type;
    public Sprite icon;
    public int ID;
    public int CardRandomizer()
    {
        if (type)
        {
            cardValue = Random.Range(0, 3);
            return cardValue;
        }
        
    cardValue = Random.Range(0, 10);
    return cardValue;
        
    }
    public Card(int cardValue, bool type)
    {
        this.cardValue = cardValue;
        this.type = type;
    }
    public Card(Card card)
    {
        this.cardValue = card.cardValue;
        this.type = card.type;
    }
}