using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FUTURE DEVELOPMENT : PLAN IMPLEMENTATION SO LVL CAN BE DETECTED FOR INCREASE IN HEALTH

public class HealthSystem : MonoBehaviour
{
    private static float playerCurrentHealth = 0;
    private static int[] maxPlayerHealth = { 10, 15, 20, 25};
    [SerializeField] private static int levelNum;

    void Start()
    {
        playerCurrentHealth = maxPlayerHealth[1];
    }

    public static float GetCurrentHealth() { return playerCurrentHealth; }

    public static int getMaxHealth()
    {
        return maxPlayerHealth[levelNum];
    }
}
