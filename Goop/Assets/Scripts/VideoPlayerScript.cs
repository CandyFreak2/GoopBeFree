using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class VideoButtonController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Image spaceBar;
    public TextMeshProUGUI skipText;

    public float targetOpacity = 1f;
    public float spacebarHoldTime = 3f;

    public bool isEndCutscene = false;

    private float startOpacity = 0f;
    private Coroutine opacityCoroutine;
    private bool isActivated = false;
    private bool isSpacebarDown = false;
    private float spacebarHoldTimer = 0f;

    void Start()
    {
        Color textColor = skipText.color;
        textColor.a = 0f;
        skipText.color = textColor;

        Color imageColor = spaceBar.color;
        imageColor.a = 0f;
        spaceBar.color = imageColor;

        startOpacity = 0f;

        videoPlayer.loopPointReached += OnVideoEnded;
    }

    void Update()
    {
        if (!isActivated)
        {
            isActivated = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacebarDown = true;
            opacityCoroutine = StartCoroutine(ChangeOpacityOverTime());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacebarDown = false;
            ResetOpacity();
            spacebarHoldTimer = 0f;
        }

        if (isSpacebarDown && !isEndCutscene)
        {
            spacebarHoldTimer += Time.deltaTime;

            if (spacebarHoldTimer >= spacebarHoldTime && videoPlayer.time >= 3f)
            {
                SceneManager.LoadScene("LevelOne");
            }
        }
    }

    IEnumerator ChangeOpacityOverTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < spacebarHoldTime)
        {
            float newOpacity = Mathf.Lerp(startOpacity, targetOpacity, elapsedTime / spacebarHoldTime);
            spaceBar.color = new Color(spaceBar.color.r, spaceBar.color.g, spaceBar.color.b, newOpacity);
            skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, newOpacity);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spaceBar.color = new Color(spaceBar.color.r, spaceBar.color.g, spaceBar.color.b, targetOpacity);
    }

    void ResetOpacity()
    {
        if (opacityCoroutine != null)
        {
            StopCoroutine(opacityCoroutine);
        }
        spaceBar.color = new Color(spaceBar.color.r, spaceBar.color.g, spaceBar.color.b, 0f);
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0f);
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        if (!isEndCutscene) {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
