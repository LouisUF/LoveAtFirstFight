using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 6;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerHealth PlayerHealth;   
    // Start is called before the first frame update
    void Start()
    {
        hearts[0].sprite = fullHeart;
        hearts[1].sprite = fullHeart;
        hearts[2].sprite = fullHeart;
        hearts[3].enabled = false;
        hearts[4].enabled = false;
        hearts[5].enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Heart"))
        {
            health = PlayerHealth.health;
            if (health <= maxHealth)
            {
                hearts[health - 1].enabled = true;
            }
        }
    }

    public void UpdateHealth()
    {
        health = PlayerHealth.health;
        if (health <= maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }





}
