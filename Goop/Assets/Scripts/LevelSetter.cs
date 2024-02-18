using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private Action<int> levelSetCallback;

    public void SetLevelCallback(Action<int> callback)
    {
        levelSetCallback = callback;
        levelSetCallback?.Invoke(levelNumber);
    }

    public int GetLevelNumber()
    {
        return levelNumber;
    }
}