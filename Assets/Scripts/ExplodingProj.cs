using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform proj;
    public GameObject projectile;
    public float bulletSpeed = 5f;

    void Start()
    {
        GameObject topBorder = GameObject.FindGameObjectWithTag("TopBorder");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), topBorder.GetComponent<Collider2D>());

        GameObject pickup = GameObject.FindGameObjectWithTag("Pickup Ability");
        if(pickup != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), pickup.GetComponent<Collider2D>());
        }
      
    }

    // Update is called once per frame

    void Update()
    {
        if (proj.position.y <= 0) 
        {
            float angle = 0f;
            for (int i = 0; i < 6; i++)
            {
              
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet.transform.Rotate(0, 0, angle);
                float radians = Mathf.Deg2Rad * angle;
                Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed * 1.2f);
                float newAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0,newAngle));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(force, ForceMode2D.Impulse);

                angle += 60;

            }
            angle = 0f;
            for (int i = 0; i < 6; i++)
            {

                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet.transform.Rotate(0, 0, angle);
                float radians = Mathf.Deg2Rad * angle;
                Vector2 force = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * (bulletSpeed * 0.8f);
                float newAngle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg + 90;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(force, ForceMode2D.Impulse);

                angle += 60;

            }

            Destroy(gameObject);
        }
    }

}
