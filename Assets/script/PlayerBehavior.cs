using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Item;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public SpriteRenderer[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public List<Itemlist> items = new List<Itemlist>();


    void Start()
    {
        AmuletoCurativo item = new AmuletoCurativo();
        items.Add(new Itemlist(item, item.GiveName(), 1));
        StartCoroutine(CallItemUpdate());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > i)
            {
                hearts[i].sprite = FullHeart;
            }
            else hearts[i].sprite = EmptyHeart;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    void Update()
    {

    }
    IEnumerator CallItemUpdate()
    {
        foreach (Itemlist i in items)
        {
            i.item.Update(this, i.stacks);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(CallItemUpdate());
    }
}
