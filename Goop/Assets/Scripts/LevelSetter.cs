using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] private int levelNumber = 1;

    public int getLevelNumber()
    {
        return levelNumber;
    }
}
