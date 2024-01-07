using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidIndicatorScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject Acid;
    public Color startColor = Color.white;
    public Color endColor = Color.red;
    public float transitionDuration = 2f; 

    private float elapsedTime = 0f;

    void Start()
    {
       StartCoroutine(spawnAcid());
        Destroy(gameObject, 2.0f);
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = startColor;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / transitionDuration);
        spriteRenderer.color = Color.Lerp(startColor, endColor, t);
    }

    IEnumerator spawnAcid()
    {
        yield return new WaitForSeconds(1.9f);
        Instantiate(Acid, transform.position, Quaternion.identity);
    }
}
