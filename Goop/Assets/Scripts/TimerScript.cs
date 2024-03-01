using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    private bool isTimerRunning = true;

    [Header("Timer Settings")]
    public float currentTime;

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            SetTimerStyle(minutes, seconds);
        }
    }

    private void SetTimerStyle(int min, int sec)
    {
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void SetIsTimerRunning(bool shouldContinue)
    {
        isTimerRunning = shouldContinue;
    }

    public void SaveTimeForCurrentLevel(int levelIndex)
    {
        StaticData.timeValuesToKeep[levelIndex] = currentTime;
    }
}