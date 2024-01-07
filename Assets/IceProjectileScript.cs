using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectileScript : MonoBehaviour
{
    void Start()
    {
        GameObject dragon = GameObject.FindGameObjectWithTag("Dragon");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), dragon.GetComponent<Collider2D>());
        GameObject topBorder = GameObject.FindGameObjectWithTag("TopBorder");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), topBorder.GetComponent<Collider2D>());
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border") || collision.CompareTag("TopBorder"))
        {

            Destroy(gameObject);

        }

    }
}
