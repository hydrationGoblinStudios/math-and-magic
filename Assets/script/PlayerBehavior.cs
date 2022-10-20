using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public int health;
    public SpriteRenderer[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > i)
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
}
