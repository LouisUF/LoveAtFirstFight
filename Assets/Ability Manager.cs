using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public Slider dashCooldown;
    public Image fill;
    public PlayerMovment playerMovement;
    private bool isCooldown = false;
    float coolDownTime;
    private float coolDownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        dashCooldown.GetComponent<Slider>().value = 0;
        coolDownTime = playerMovement.dashCooldown;
        fill.fillAmount = 0;
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.canDash)
        {
            dashCooldown.GetComponent<Slider>().value = 1;

        }
        if (playerMovement.isDashing)
        {
            trigger();
        }
        applyCooldown();

    }

    public void applyCooldown()
    {
        coolDownTimer -= Time.deltaTime;

        if (coolDownTimer < 0.0f)
        {
            fill.fillAmount = 0;

        }
        else
        {
            fill.fillAmount = coolDownTimer / coolDownTime;
            
        }
    }

    public void trigger()
    {
        coolDownTimer = coolDownTime;
    }


}
