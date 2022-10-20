using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] enemyList;
    public GameObject enemyParent;
    public GameObject dragaopitola;
    public EnemyBehavior dragao;
    public bool dargon;

    private void Start()
    {
        GameObject enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)]);
        enemy.transform.parent = enemyParent.transform;
        enemy.transform.position = enemyParent.transform.position;
        if (dargon)
        {
            dragao = enemy.GetComponent<EnemyBehavior>();
        }
    }
    public void Update()
    {
        if (dargon && dragao.health <= 3)
        {
            puxaAGlock();
        }
    }

    public void puxaAGlock()
    {
        dragao.health = 13131;
        dragao.gameObject.SetActive(false);
        GameObject enemy = Instantiate(dragaopitola);
        enemy.transform.parent = enemyParent.transform;
        enemy.transform.position = enemyParent.transform.position;

    }
}
