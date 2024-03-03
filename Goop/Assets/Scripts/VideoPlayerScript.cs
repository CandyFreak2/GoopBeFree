using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoButtonController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button button;
    public float targetOpacity = 1f;
    public float transitionDuration = 1f;
    public float activationTime = 16f; 

    private float startOpacity = 0f;
    private Coroutine opacityCoroutine;
    private bool isActivated = false;

    void Start()
    {
        button.interactable = false; 
        startOpacity = button.image.color.a;
    }

    void Update()
    {
        if (!isActivated && videoPlayer.time >= activationTime)
        {
            isActivated = true;
            opacityCoroutine = StartCoroutine(ChangeOpacityOverTime());
        }
    }

    IEnumerator ChangeOpacityOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / transitionDuration);
            button.image.color = new Color(button.image.color.r, button.image.color.g, button.image.color.b, newOpacity);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.image.color = new Color(button.image.color.r, button.image.color.g, button.image.color.b, targetOpacity);
        button.interactable = true; 
    }
}
