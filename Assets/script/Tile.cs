using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public PlayerController playerController;
    public Collider2D collider;
    public float valor;
    void Start()
    {
       playerController = FindObjectOfType<PlayerController>();
    }
    void OnMouseDown()
    {
        Debug.Log("butao clicadu");
        playerController.CheckForMovement(valor,gameObject.transform.position);
    }
}
