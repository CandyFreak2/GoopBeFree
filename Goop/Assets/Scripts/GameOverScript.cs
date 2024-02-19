using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUI, goop;

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
        if (goop.TryGetComponent<Rigidbody>(out var goopRB))
        {
            goopRB.velocity = Vector2.zero;
        }
        if (goop.TryGetComponent<GoopMovement>(out var goopMovement))
        {
            goopMovement.SetIsGoopDead(false);
        }

    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
