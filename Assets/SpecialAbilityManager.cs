using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilityManager : MonoBehaviour
{
    public Slider abilityCooldown;
    public Image fill;
    public Image abilityIcon;
    public Sprite[] icons;
    public PlayerMovment playerMovement;
    public BulletReversal bulletReversal;
    private bool isCooldown = false;
    float coolDownTime;
    private float coolDownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown.GetComponent<Slider>().value = 0;
        fill.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.canClear)
        {
            abilityIcon.sprite = icons[0];
            abilityCooldown.GetComponent<Slider>().value = 1;
            coolDownTime = playerMovement.clearCooldown;

        } else if (bulletReversal.canSlow)
        {
            abilityIcon.sprite= icons[1];
            abilityCooldown.GetComponent<Slider>().value = 1;
            coolDownTime = bulletReversal.slowCooldown;
        }
        if(Input.GetMouseButtonDown(1) && (!playerMovement.canClear|| !bulletReversal.canSlow) &&!isCooldown) {
            isCooldown = true;
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
            isCooldown = false;

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
