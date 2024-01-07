using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textBoxPrances: MonoBehaviour
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
    public GameObject tower;
    private Renderer objectRenderer;
    private BoxCollider2D objectCollider;
    public GameObject dragonShadow;
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
        textBox.text = name;
        tower = GameObject.FindWithTag("Tower");
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
            DragonBehavior dragonScript = Dragon.GetComponent<DragonBehavior>();
            dragonScript.phase = 2;
            dragonScript.dragonSprite.sprite = dragonScript.newDragon;
            if(objectRenderer != null)
            {
                objectRenderer.enabled = false;
            } else
            {
                Debug.Log("null");
            }
            if (objectCollider != null)
            {
                objectCollider.enabled = false;
            }
            else
            {
                Debug.Log("null");
            }
            Destroy(textBox);
            StartCoroutine(Dance());
            // Keep this as last line
            otherOption = GameObject.Find("Dances(Clone)");
            Destroy(otherOption);
            
        }
    }

    IEnumerator Dance()
    {

        for (int i = 0; i < 2; i++)
        {
            Dragon.transform.rotation = Quaternion.Euler(0f, 0f, 25f);
            yield return new WaitForSeconds(0.5f);
            Dragon.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
            yield return new WaitForSeconds(0.5f);
        }
        Vector2 pos = new Vector2(0, 5);
        Instantiate(dragonShadow, pos, Quaternion.identity);
        
        yield return new WaitForSeconds(1.0f);
        if (tower != null)
        {
            tower.SetActive(false);
        } else
        {
            Debug.Log("Not set");
        }

        Dragon.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 targetPosition = new Vector3(0f, 1f, 0f);
        Dragon.transform.position = targetPosition;
        Dragon.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);


        Destroy(gameObject);
    }
}
