using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragaoPuxaAGlock : MonoBehaviour
{
    public EnemyBehavior dragao;
    public GameObject dragaoPitola;

    void Update()
    {
        if(dragao.health <= 3)
        {
            dragao.health = 10;
            transform.position = new Vector3(120, 120, 0);
            
        }
    }
}
