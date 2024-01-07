using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public AudioManager audioManager;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        if (first)
        {
            first = false;
            audioManager.Play("Music");
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetSceneByName("MainMenu").isLoaded && !first)
        {
            Destroy(gameObject);
        }
    }
}
