using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public delegate void DragEndedDelegate(Material materialObject, CardDisplay cardDisplay);
    public DragEndedDelegate dragEndedCallback; 
    public CardDisplay card;
    public int cardvalue;
    private bool held;

    private void OnMouseDown()
    {
        held = true;
    }
    public void OnMouseUp()
    {
        if (held)
        {
            Debug.Log("drag ended");   
        }
        held = false;
        dragEndedCallback(this, card);
    }
    public void Update()
    {
        cardvalue = card.cardValue;
    }
}
