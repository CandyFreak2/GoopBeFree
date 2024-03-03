using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
        Time.timeScale = 1.0f;
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
        Time.timeScale = 1.0f;
    }
    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
