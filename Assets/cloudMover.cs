using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMover : MonoBehaviour
{
    private float speed;
    public Transform despawnPoint;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (despawnPoint.position.x > transform.position.x) 
        {
            transform.position = new Vector3(spawnPoint.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
