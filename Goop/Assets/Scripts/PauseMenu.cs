using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject pausePanel;
    public TimerScript timer;
    public GoopMovement goop;

    private void Awake()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Debug.Log("Resuming Game");
                Resume();
            }
            else
            {
                Debug.Log("Pausing Game");
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
            isGamePaused = false;
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }

    public bool GetIsGamePaused()
    {
        return isGamePaused;
    }

    public void RestartButton()
    {
        if (timer != null)
        {
            timer.ResetTimer();
        }
        if (goop != null)
        {
            goop.ResetFlip();
        }
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void BackToMainScreen()
    {
        if (timer != null)
        {
            timer.ResetTimer();
        }
        if (goop != null)
        {
            goop.ResetFlip();
        }
        SceneManager.LoadScene("MainScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}