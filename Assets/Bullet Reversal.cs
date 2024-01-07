using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReversal : MonoBehaviour
{
    public bool canSlow = false;
    public float slowCooldown = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canSlow)
        {
            StartCoroutine(slowBullet());
        }
    }
    private IEnumerator slowBullet()
    {
        canSlow = false;
        Vector2 bl = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 tr = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Collider2D[] objects = Physics2D.OverlapAreaAll(bl, tr);
        foreach (var item in objects)
        {
            if (item.CompareTag("Projectile")||item.CompareTag("IceProjectile"))
            {
                Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
                rb.velocity *= -0.75f;
            }
        }
        yield return new WaitForSeconds(slowCooldown);
        canSlow = true;
    }
}
