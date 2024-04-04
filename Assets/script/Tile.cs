using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public PlayerController playerController;
    public Collider2D collider2d;
    public float valor;
    public int x, y;
    public TextMeshPro valorTexto;
    void Start()
    {
       playerController = FindObjectOfType<PlayerController>();
       valorTexto = GetComponent<TextMeshPro>();
        RandomizeSelfValue();
    }
    void OnMouseDown()
    {
        Debug.Log("butao clicadu");
        playerController.CheckForMovement(valor,gameObject.transform.position,x,y);
    }
    void RandomizeSelfValue()
    {
        valor = Random.Range(0,27);
        if (playerController.currentCoordinate[1] >= y-playerController.range & playerController.currentCoordinate[1] <= y+playerController.range  && playerController.currentCoordinate[0] >= x - playerController.range & playerController.currentCoordinate[0] <= x + playerController.range)
        {
            valorTexto.text = valor.ToString();
        }
    }
}
