using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathManager : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when clicked.
    public GameObject audio;
    public AudioManager audioManager;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("AudioManager");
        audioManager = audio.GetComponent<AudioManager>();
    }

    public void death()
    {
        StartCoroutine(deathRoutine());
    }

    IEnumerator deathRoutine()
    {
        audioManager.Play("Death");
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
