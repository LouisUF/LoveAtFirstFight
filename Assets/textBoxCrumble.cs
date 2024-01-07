using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textBoxCrumble : MonoBehaviour
{
    /*
     * Hello Team :)
     * 
     * This is a template class for text pickups
     * I will outline any code to not touch bc it is neccesary to maintain cooperation with the SliderManager(poem writing) script
     *
     * Other than that, copy it and customize it however needed to change aspects of the game like palyer abilities and dragon stats
     */

    //---------------------------------------------------------------------//
    public TextMeshProUGUI textBox;
    public string name;
    public string text;
    public GameObject UI_Overlay;
    public GameObject Player;
    public GameObject Dragon;
    private GameObject otherOption;
    public GameObject boulder;
    public GameObject CameraObject;
    public ScreenShake screenShake;
    private Renderer objectRenderer;
    private BoxCollider2D objectCollider;
    //---------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<BoxCollider2D>();
        //---------------------------------------------------------------------//
        UI_Overlay = GameObject.Find("UI Overlay");
        Player = GameObject.Find("Bard");
        Dragon = GameObject.Find("Dragon");
        CameraObject = GameObject.FindWithTag("Canvas");
        screenShake = CameraObject.GetComponent<ScreenShake>();
        textBox.text = name;
        //---------------------------------------------------------------------//
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //---------------------------------------------------------------------//
            UI_Overlay.GetComponent<SliderManager>().Collect(text);
            //---------------------------------------------------------------------//

            //Add extra code here
            objectRenderer.enabled = false;
            objectCollider.enabled = false;
            Destroy(textBox);
            StartCoroutine(startShaking());
            // Keep this as last line
            otherOption = GameObject.Find("Rumble(Clone)");
            Destroy(otherOption);

            
        }
    }

    IEnumerator startShaking()
    {
        screenShake.ShakeScreen();
        yield return new WaitForSeconds(2.0f);
        float randomX = Random.Range(-9f, 9f);
        float randomY = Random.Range(-4f, 0.6f);
        Vector2 randomPos = new Vector2(randomX, randomY);
        Instantiate(boulder, randomPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
