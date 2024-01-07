using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainToGame : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when clicked.
    public string soundName;
    public AudioManager audioManager;
    public GameObject fadeOut;


    public void loadScene()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        audioManager.Play(soundName);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
