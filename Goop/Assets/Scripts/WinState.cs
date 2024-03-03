using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    [SerializeField] public TimerScript timer;

    private bool hasWonLevelOne = false, hasWonLevelTwo = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent<GoopMovement>(out _))
            {
                Debug.LogError("Player Script is Null");
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne"))
            {
                hasWonLevelOne = true;
                Debug.Log("Completed level 1: " + hasWonLevelOne);
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
            {
                hasWonLevelTwo = true;
                Debug.Log("Completed level 2: " + hasWonLevelTwo);
            }
        }

        if (hasWonLevelOne || hasWonLevelTwo)
        {
            timer.SetIsTimerRunning(false);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            timer.SaveTimeForCurrentLevel(currentSceneIndex);
            Debug.Log("Time " + currentSceneIndex +": " + timer.currentTime);
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        if (hasWonLevelOne && hasWonLevelTwo)
        {
            timer.SetIsTimerRunning(false);
            SceneManager.LoadScene("EndCutscene");
        }
    }
}
