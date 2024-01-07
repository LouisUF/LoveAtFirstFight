using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShadowScript : MonoBehaviour
{
   
    void Update()
    {
        transform.Translate(Vector2.down * 9 * Time.deltaTime);
    }
}
