using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int numBounces = 0;
    public int maxBounces = 2;
    Rigidbody2D rb;
    void Start()
    {
        GameObject topBorder = GameObject.FindGameObjectWithTag("TopBorder");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), topBorder.GetComponent<Collider2D>());
        GameObject dragon = GameObject.FindGameObjectWithTag("Dragon");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), dragon.GetComponent<Collider2D>());
        Destroy(gameObject, 10f);
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            if (numBounces >= maxBounces)
            {
                Destroy(gameObject);
            }
            else
            {
                numBounces++;

            }
        }
    }
}
