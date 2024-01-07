using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;
    [SerializeField] float invulnerabilityDuration = 1f;
    public PlayerMovment playerMovement;
    public bool isInvulnerable = false;
    public bool invulnerableBuff = false;
    public HealthDisplay healthDisplay;
    public HealthbarManager healthbarManager;
    public GameObject deathManager;

    public GameObject audio;
    private AudioManager audioManager;
    void Start()
    {
        audio = GameObject.Find("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("You lose!");
            deathManager.GetComponent<deathManager>().death();
            gameObject.SetActive(false);

            //game over
        }
        if (invulnerableBuff)
        {
            invulnerabilityDuration = 2f;
        }
        //isInvulnerable = playerMovement.isDashing;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup Ability") || collision.gameObject.CompareTag("Pickup Words"))
        {
            healthbarManager.healthbarNumber++;
            audioManager.Play("TextPickup");
        }
    }

    private IEnumerator triggerIFrames(float time)
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(time);
        isInvulnerable = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && !isInvulnerable)
        {
            Destroy(collision.gameObject);
            health--;
            audioManager.Play("Hurt");
            healthDisplay.UpdateHealth();
            StartCoroutine(triggerIFrames(invulnerabilityDuration));
        }
        if(collision.gameObject.CompareTag("Acid") && !isInvulnerable)
        {
            health--;
            audioManager.Play("Hurt");
            Destroy(collision.gameObject);
            healthDisplay.UpdateHealth();
            StartCoroutine(triggerIFrames(invulnerabilityDuration));
        }
        if(collision.gameObject.CompareTag("IceProjectile") && !isInvulnerable)
        {
            health--;
            audioManager.Play("Hurt");
            healthDisplay.UpdateHealth();
            StartCoroutine(triggerIFrames(invulnerabilityDuration));
        }
        if (collision.CompareTag("Heart"))
        {
            Destroy(collision.gameObject);
            if(health < 6)
            {
                audioManager.Play("Heal");
                health++;
                healthDisplay.UpdateHealth();
            }
        }
        
    }

   
    public void globalIFrames(float time)
    {
        StartCoroutine(triggerIFrames(time));
    }
}

