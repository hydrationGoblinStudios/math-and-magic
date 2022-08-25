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
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void OnMouseDown()
    {
        cardvalue = card.cardValue;
        held = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
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
    private void OnMouseDrag()
    {
        if (held)
        {
          transform.localPosition = spriteDragStartPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition;
        }
    }
    
}
