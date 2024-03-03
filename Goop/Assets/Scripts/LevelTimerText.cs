using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimerText : MonoBehaviour
{
    public TextMeshProUGUI completionTimesText;
    private int levelOne = 3; 
    private int levelConstraint = 4; 

    void Start()
    {
        DisplayCompletionTimes();
    }
    void DisplayCompletionTimes()
    {
        string completionTimes = "Completion Times:\n";
        float overallTime = 0f; 

        for (int i = levelOne; i <= levelConstraint; i++)
        {
            float completionTime = PlayerPrefs.GetFloat("Level" + i + "Time", -1f);
            if (completionTime >= 0)
            {
                int minutes = Mathf.FloorToInt(completionTime / 60);
                int seconds = Mathf.FloorToInt(completionTime % 60);
                completionTimes += "Level " + (i - (levelOne - 1)) + ": " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\n";
                overallTime += completionTime; 
            }
            else
            {
                completionTimes += "Level " + (i - (levelOne - 1)) + ": Not Completed\n";
            }
        }

        int overallMinutes = Mathf.FloorToInt(overallTime / 60);
        int overallSeconds = Mathf.FloorToInt(overallTime % 60);
        completionTimes += "\nOverall Time: " + string.Format("{0:00}:{1:00}", overallMinutes, overallSeconds);

        completionTimesText.text = completionTimes;
    }
}
