using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public GameOverScript gameOver;
    private HealthSystem healthSystem;
    private GoopMovement goopMovement;
    private bool isGoopDead = false;

    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        GameObject goopObject = GameObject.FindWithTag("Player");
        if (goopObject != null)
        {
            goopMovement = goopObject.GetComponent<GoopMovement>();
        }
        else
        {
            Debug.LogWarning("GoopMovement script not found on any GameObject with the 'Player' tag.");
        }

    }

    void Update()
    {
        // Update healthAmount in each frame
        //float healthAmount = HealthSystem.GetCurrentHealth();

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

            if (healthSystem.GetCurrentHealth() <= 0 && !isGoopDead)
            {
                isGoopDead = true;
                gameOver.GameOver();
                healthSystem.ResetHealth();
                if (goopMovement != null)
                {
                    goopMovement.SetIsGoopDead(isGoopDead);
                }
                else
                {
                    Debug.LogWarning("GoopMovement script reference is null.");
                }
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