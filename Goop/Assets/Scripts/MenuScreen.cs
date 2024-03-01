using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void LevelSelectButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("LevelSelect");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}