using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    [SerializeField] public TimerScript timer;

    public bool hasWonLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasWonLevel = true;
            if (!collision.TryGetComponent<GoopMovement>(out _))
            {
                Debug.LogError("Player Script is Null");
            }
        }

        if (hasWonLevel && timer != null) 
        {
            timer.SetIsTimerRunning(true);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            timer.SaveTimeForCurrentLevel(currentSceneIndex);
            SceneManager.LoadScene("WinGameScene");
        }
    }

    public bool GetHasWonLevel() => hasWonLevel;
}
