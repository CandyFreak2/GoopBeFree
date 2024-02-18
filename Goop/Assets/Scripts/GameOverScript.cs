using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
