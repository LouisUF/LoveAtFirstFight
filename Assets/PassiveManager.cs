using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveManager : MonoBehaviour
{
    public Image passiveIcon;
    public Sprite[] icons;

    public PlayerHealth playerHealth;
    public PlayerMovment playerMovment;

    // Start is called before the first frame update
    void Start()
    {
        passiveIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovment.speedBuff)
        {
            passiveIcon.enabled = true;
            passiveIcon.sprite = icons[0];
        }
        if (playerHealth.invulnerableBuff)
        {
            passiveIcon.enabled = true;
            passiveIcon.sprite = icons[1];
        }
    }
}
