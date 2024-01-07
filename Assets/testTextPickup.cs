using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class testTextPickup : MonoBehaviour
{
    /*
     * Hello Team :)
     * 
     * This is a template class for text pickups
     * I will outline any code to not touch bc it is neccesary to maintain cooperation with the SliderManager(poem writing) script
     *
     * Other than that copy it into a new script and customize it however needed to change aspects of the game like palyer abilities and dragon stats
     */

    //---------------------------------------------------------------------//
    public TextMeshProUGUI textBox;
    public string name;
    public string text;
    public GameObject UI_Overlay;
    public GameObject Player;
    public GameObject Dragon;
    public GameObject Popup;
    
    
    //---------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        //---------------------------------------------------------------------//
        UI_Overlay = GameObject.Find("UI Overlay");
        Player = GameObject.Find("Bard");
        Dragon = GameObject.Find("Dragon");
        Popup = GameObject.Find("AbilityPopup");

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
            Player.GetComponent<PlayerMovment>().canDash = true;
            
            Popup.GetComponent<AbilityPopup>().abilityIndex = 0;
            Popup.GetComponent<AbilityPopup>().popup();
            // Keep this as last line
            Destroy(gameObject);
        }
    }
}
