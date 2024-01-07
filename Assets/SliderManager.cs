using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SliderManager : MonoBehaviour
{
    public List<string> textList_1 = new List<string>();
    public List<string> textList_2 = new List<string>();
    public List<float> stopTimes_1 = new List<float>();
    public List<float> stopTimes_2 = new List<float>();
    public List<float> stopTimes_3 = new List<float>();

    public List<GameObject> textPickups = new List<GameObject>();
    public List<int> pickupQuantity = new List<int>();

    public Slider quillFill_1;
    public Slider quillFill_2;
    public GameObject quill_1;
    public GameObject quill_2;
    public TextMeshProUGUI textBox_1;
    public TextMeshProUGUI textBox_2;
    public String fillWords;
    public float decreaseRate;
    public float waitTime_1;
    public float waitTime_2;
    public bool wordCollected;

    private int lineCounter;
    private int pickupCounter;
    private int pickupNum;
    private String firstPart;
    private String lastPart;
    private bool firstLineDone;
    private bool firstTime;
    private bool firstTime2;

    private Vector3 center = new Vector3(0,-1,0);
    private Vector3 left = new Vector3(-4,-1,0);
    private Vector3 right = new Vector3(4,-1,0);


    // Start is called before the first frame update
    void Start()
    {
        fillWords = "";
        lineCounter = 0;
        pickupCounter = 0;
        wordCollected = false;
        firstLineDone = false;
        firstTime = true;
        firstTime2 = true;
        quill_1.SetActive(true);
        quill_2.SetActive(false);
        quillFill_1.value = quillFill_1.maxValue;
        quillFill_2.value = quillFill_2.maxValue;
        //underlineIndex = textList2[lineCounter].IndexOf("_");
        //firstPart = textList[lineCounter].Substring(0, underlineIndex);
        //lastPart = textList[lineCounter].Substring(underlineIndex + 1);
        textBox_1.text = textList_1[lineCounter];
        textBox_2.text = textList_2[lineCounter];
    }

    // Update is called once per frame
    void Update()
    {
        if (quillFill_1.value > stopTimes_1[lineCounter]) 
        {
            quillFill_1.value -= decreaseRate * Time.deltaTime;
        }
        else if(!firstLineDone)
        {
            StartCoroutine(waitFirstLine(waitTime_1));
        }
        if (firstLineDone && quillFill_2.value > stopTimes_2[lineCounter]) 
        {
            firstTime2 = true;
            quillFill_2.value -= decreaseRate * Time.deltaTime;
        }
        else if (firstLineDone)
        {
            if (firstTime2)
            {
                firstTime2 = false;
                spawnPickups();
            }
        }
        if (wordCollected && firstLineDone && quillFill_2.value > stopTimes_3[lineCounter])
        {
            firstTime = true;
            quillFill_2.value -= decreaseRate * Time.deltaTime;
        }
        else if (wordCollected && firstLineDone && lineCounter != 5) {
            StartCoroutine(waitSecondLine(waitTime_2));
        }
    }

    public void Collect(String words)
    {
        fillWords = words;
        wordCollected = true;
        textBox_2.text = textList_2[lineCounter] + fillWords;
    }

    public void spawnPickups()
    {
        pickupNum = pickupQuantity[lineCounter];
        if (pickupNum == 1)
        {
            if (lineCounter==5)
            {
                Vector3 charmSpot = new Vector3(0,0.2f,0);
                Instantiate(textPickups[pickupCounter], charmSpot, transform.rotation);
            }
            else
            {
                Instantiate(textPickups[pickupCounter], center, transform.rotation);
                pickupCounter++;
            }
        }
        else if(pickupNum == 2)
        {
            Instantiate(textPickups[pickupCounter], left, transform.rotation);
            pickupCounter++;
            Instantiate(textPickups[pickupCounter], right, transform.rotation);
            pickupCounter++;
        }
    }
    IEnumerator waitFirstLine(float waitTime)
    {
        quill_1.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        quill_2.SetActive(true);
        firstLineDone = true;

    }

    IEnumerator waitSecondLine(float waitTime)
    {
        quill_2.SetActive(false);
        yield return new WaitForSeconds(waitTime_2);
        if (firstTime) 
        { 
            firstTime = false;
            lineCounter += 1;
        }
        quillFill_1.value = quillFill_1.maxValue;
        quillFill_2.value = quillFill_2.maxValue;
        quill_1.SetActive(true);
        wordCollected = false;
        firstLineDone = false;
        fillWords = "";
        textBox_1.text = textList_1[lineCounter];
        textBox_2.text = textList_2[lineCounter];
    }
}
