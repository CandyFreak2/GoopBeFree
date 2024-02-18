using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float playerCurrentHealth = 0;
    private int[] maxPlayerHealth = { 10, 15, 20, 25 };
    [SerializeField] private int levelNum;

    private void Awake()
    {
        LevelSetter levelSetter = gameObject.AddComponent<LevelSetter>();
        levelSetter.SetLevelCallback(OnLevelSet);
    }

    private void OnLevelSet(int level)
    {
        levelNum = level;
        playerCurrentHealth = maxPlayerHealth[levelNum];
        Debug.Log("Player Health: " + playerCurrentHealth);
    }

    public float GetCurrentHealth() { return playerCurrentHealth; }

    public void SetCurrentHealth(float change)
    {
        playerCurrentHealth += change;
    }

    public void ResetHealth() { playerCurrentHealth = maxPlayerHealth[levelNum]; }

    public int GetMaxHealth()
    {
        return maxPlayerHealth[levelNum];
    }
}