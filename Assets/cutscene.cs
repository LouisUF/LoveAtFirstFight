using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour
{
    public Animator animator;
    public GameObject fadeOut;
    public string sceneToLoad;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutScene());
    }


    IEnumerator cutScene()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("flip1");
        yield return new WaitForSeconds(5);
        animator.SetTrigger("flip2");
        yield return new WaitForSeconds(5);
        animator.SetTrigger("flip3");
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
