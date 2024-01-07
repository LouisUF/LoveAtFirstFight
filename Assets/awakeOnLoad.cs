using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeOnLoad : MonoBehaviour
{
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn.SetActive(true);
    }
}
