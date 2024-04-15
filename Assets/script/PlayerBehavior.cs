using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Item;

public class PlayerBehavior : MonoBehaviour
{
    public int maxhealth;
    public int health;
    public int Damage;
    public SpriteRenderer[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public List<Itemlist> items = new List<Itemlist>();

    //lembrar de tirar o item no start depois
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
        if (health > maxhealth)
        {
            health = maxhealth;
        }
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
