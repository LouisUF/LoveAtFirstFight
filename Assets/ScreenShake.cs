using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;

    public float shakeDuration = 1.2f;

    private Camera mainCamera;

    private Vector3 initialCameraPosition;

    private bool isShaking = false;

    void Start()
    {
        mainCamera = Camera.main;

        initialCameraPosition = mainCamera.transform.position;

    }

    public void ShakeScreen()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    IEnumerator ShakeCoroutine()
    {
        isShaking = true;

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector2 randomOffset = Random.insideUnitCircle * shakeIntensity;

            mainCamera.transform.position = initialCameraPosition + new Vector3(randomOffset.x, randomOffset.y, 0);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = initialCameraPosition;

        isShaking = false;
    }
}
