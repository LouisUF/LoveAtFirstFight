using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPopup : MonoBehaviour
{
    public Image abilityIcon;
    public TextMeshProUGUI abilityDescription;

    public Sprite[] icons;
    [TextArea]
    public string[] description;

    public int abilityIndex;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(true);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        
           
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKey(KeyCode.Escape) && isPaused)
        {
            //gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1f;
        }


       
    }

    public void popup()
    {
        //gameObject.SetActive(true);
        gameObject.transform.localScale = new Vector3(1.032525f, 1.032525f, 1.032525f);
        isPaused = true;
        Debug.Log("popup");
        Time.timeScale = 0f;
        abilityIcon.sprite = icons[abilityIndex];
        abilityDescription.text = description[abilityIndex];
    }
}
