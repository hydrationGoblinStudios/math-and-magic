using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{

    public float timer;
    public float timerMax;
    public Transform[] LineTransform;
    public ProjectileBehavior ProjectilePrefab;
    public TextMeshPro textMeshPro;
    public int health;
    public GameObject wipe;
    private void Awake()
    {
        timer = timerMax;
    }
    public void Start()
    {
        textMeshPro.text = "" + health;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        textMeshPro.text = "" + health;
    }
    public void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(DisingageInMagickerfuffles());
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerMax;
            send(Random.Range(0, 3));
        }
    }
    public void send(int x)
    {
        Debug.Log(x);
        Instantiate(ProjectilePrefab, LineTransform[x].position, transform.rotation);
    }
    public IEnumerator DisingageInMagickerfuffles()
    {
        wipe.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        transform.position = new Vector2(120, 120);
        yield return new WaitForSeconds(0.5f);
        SceneManager.UnloadScene(2);
    }

}
