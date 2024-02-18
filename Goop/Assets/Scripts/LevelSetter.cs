using UnityEngine;
using System;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private int levelNumber; // is oriented as an array
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

    public void SetLevelNumberExternal(int level)
    {
        levelNumber = level;
        levelSetCallback?.Invoke(levelNumber);
    }
}