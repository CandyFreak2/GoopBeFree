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
            if (!hasWonLevelOne && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne")))
            {
                hasWonLevelOne = true;
            }
            else if (!hasWonLevelTwo && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo")))
            {
                hasWonLevelTwo = true;
            }
            if (!collision.TryGetComponent<GoopMovement>(out _))
            {
                Debug.LogError("Player Script is Null");
            }
        }

        if (hasWonLevelOne || hasWonLevelTwo)
        {
            timer.SetIsTimerRunning(false);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        if (hasWonLevelOne && hasWonLevelTwo && timer != null)
        {
            timer.SetIsTimerRunning(true);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            timer.SaveTimeForCurrentLevel(currentSceneIndex);
            SceneManager.LoadScene("WinGameScene");
        }
    }
}
