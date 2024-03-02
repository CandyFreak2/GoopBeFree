using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    public void PlayGame()
    {
        pauseMenu.SetIsGamePaused(false);
        SceneManager.LoadSceneAsync("LevelOne");
    }

    public void LevelSelectButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}