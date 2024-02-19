using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float playerCurrentHealth = 0;
    private int[] maxPlayerHealth = { 10, 15, 20, 25 };
    [SerializeField] private LevelSetter levelSetter;

    private void Awake()
    {
        LevelSetter levelSetter = gameObject.AddComponent<LevelSetter>();
        levelSetter.SetLevelCallback(OnLevelSet);
    }

    private void OnLevelSet(int level)
    {
        playerCurrentHealth = maxPlayerHealth[level];
        Debug.Log("Player Health: " + playerCurrentHealth);
    }

    public float GetCurrentHealth() { return playerCurrentHealth; }

    public void SetCurrentHealth(float change)
    {
        playerCurrentHealth += change;
    }

    public void ResetHealth()
    {
        LevelSetter levelSetter = GetComponent<LevelSetter>();
        int currentLevel = levelSetter.GetLevelNumber();
        playerCurrentHealth = maxPlayerHealth[currentLevel];
    }

    public int GetMaxHealth()
    {
        LevelSetter levelSetter = GetComponent<LevelSetter>();
        int currentLevel = levelSetter.GetLevelNumber();
        return maxPlayerHealth[currentLevel];
    }
}