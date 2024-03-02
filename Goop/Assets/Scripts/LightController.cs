using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D lightObject;
    private float targetOpacity = 0f;
    private float transitionDuration = 3f;
    private Coroutine opacityCoroutine;

    void Start()
    {
        lightObject = GetComponent<Light2D>();
        lightObject.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lightObject.enabled = true;
            if (opacityCoroutine != null)
            {
                StopCoroutine(opacityCoroutine);
            }
            targetOpacity = 1f;
            opacityCoroutine = StartCoroutine(ChangeOpacityOverTime());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (opacityCoroutine != null)
            {
                StopCoroutine(opacityCoroutine);
            }
            targetOpacity = 0f;
            if (gameObject.activeInHierarchy)
            {
                opacityCoroutine = StartCoroutine(ChangeOpacityOverTime());
            }
        }
    }

    IEnumerator ChangeOpacityOverTime()
    {
        float startOpacity = lightObject.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / transitionDuration);
            lightObject.color = new Color(lightObject.color.r, lightObject.color.g, lightObject.color.b, newOpacity);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lightObject.color = new Color(lightObject.color.r, lightObject.color.g, lightObject.color.b, targetOpacity);
    }
}

