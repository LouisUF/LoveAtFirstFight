using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthbarManager : MonoBehaviour
{
    public Sprite healthbar0;
    public Sprite healthbar1;
    public Sprite healthbar2;
    public Sprite healthbar3;
    public Sprite healthbar4;
    public Sprite healthbar5;
    public Sprite healthbar6;
    public SpriteRenderer spriteRenderer;

    public int healthbarNumber = 0;

    public GameObject audio;
    public AudioManager audioManager;
    public GameObject fadeOut;
    public GameObject Player;

    private void Start()
    {
        audio = GameObject.Find("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
    }
    private void Update()
    {
       switch(healthbarNumber)
        {
            case 0:
                spriteRenderer.sprite = healthbar0;
                break;

            case 1:
                spriteRenderer.sprite = healthbar1;
                break;

            case 2:
                spriteRenderer.sprite = healthbar2;
                break;

            case 3:
                spriteRenderer.sprite = healthbar3;
                break;

            case 4:
                spriteRenderer.sprite = healthbar4;
                break;

            case 5:
                spriteRenderer.sprite = healthbar5;
                break;

            case 6:
                spriteRenderer.sprite = healthbar6;
                StartCoroutine(winRoutine());
                Debug.Log("You Win!");
                break;
        }
    }

    IEnumerator winRoutine()
    {
        Player.GetComponent<PlayerHealth>().isInvulnerable = true;
        audioManager.Play("Charm");
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndScene");
    }
}
