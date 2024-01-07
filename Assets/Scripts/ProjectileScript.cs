using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject topBorder = GameObject.FindGameObjectWithTag("TopBorder");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), topBorder.GetComponent<Collider2D>());
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {

            Destroy(gameObject);

        }

    }
}
