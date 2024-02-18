using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    //public GameOverScript gameOver;
    private HealthSystem healthSystem;

    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        // Deactivate the game over screen at the start
        //gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H)) { Heal(0.5f); }
        if (Input.GetKeyUp(KeyCode.T)) { TakeDamage(0.5f); }
    }

    void TakeDamage(float damage)
    {
        if (healthSystem != null)
        {
            healthSystem.SetCurrentHealth(-damage);
            UpdateHealthBar();
            Debug.Log("Ouch Level:" + healthSystem.GetCurrentHealth());

            if (healthSystem.GetCurrentHealth() <= 0)
            {
                healthSystem.ResetHealth();
                Debug.Log("HOW'D YOU DIE ITS A DEV ENV?!?!?!");
                //gameOver.Setup();
            }
        }
        else
        {
            Debug.LogWarning("HealthSystem component is not attached or initialized.");
        }
    }

    void Heal(float healthIncrease)
    {
        if (healthSystem != null)
        {
            float currentHealth = healthSystem.GetCurrentHealth();
            float maxHealth = healthSystem.GetMaxHealth();
            float amountToHeal = Mathf.Min(healthIncrease, maxHealth - currentHealth);
            if (amountToHeal > 0)
            {
                healthSystem.SetCurrentHealth(amountToHeal);
                UpdateHealthBar();
                Debug.Log("Player Healed:" + healthSystem.GetCurrentHealth());
            }
            else
            {
                Debug.Log("Player is already at full health or exceeded maximum health.");
            }
        }
        else
        {
            Debug.LogWarning("HealthSystem component is not attached or initialized.");
        }
    }


    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float maxHealth = healthSystem.GetMaxHealth();
            float currentHealth = healthSystem.GetCurrentHealth();
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        else
        {
            Debug.LogWarning("Health bar reference is null.");
        }
    }
}