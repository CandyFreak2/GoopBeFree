using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimerText : MonoBehaviour
{
    public TextMeshProUGUI completionTimesText;
    private const int numberOfLevels = 2;

    void Start()
    {
        DisplayCompletionTimes();
    }

    void DisplayCompletionTimes()
    {
        string completionTimes = "Completion Times:\n";

        for (int i = 1; i <= numberOfLevels; i++)
        {
            float completionTime = PlayerPrefs.GetFloat("Level" + i + "Time", -1f);
            if (completionTime >= 0)
            {
                int minutes = Mathf.FloorToInt(completionTime / 60);
                int seconds = Mathf.FloorToInt(completionTime % 60);
                completionTimes += "Level " + i + ": " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\n";
            }
            else
            {
                completionTimes += "Level " + i + ": Not Completed\n";
            }
        }

        completionTimesText.text = completionTimes;
    }

}