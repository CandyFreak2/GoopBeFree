using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimerText : MonoBehaviour
{
    public TextMeshProUGUI[] levelTimeTexts; 

    void Start()
    {
        for (int i = 0; i < StaticData.timeValuesToKeep.Length; i++)
        {
            float timeInSeconds = StaticData.timeValuesToKeep[i];
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            levelTimeTexts[i].text = timeString;
        }
    }
}
