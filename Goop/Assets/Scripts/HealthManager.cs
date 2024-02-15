using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    private float healthAmount = HealthSystem.GetCurrentHealth();

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyUp(KeyCode.H)) { Heal(0.5f); }
        if (Input.GetKeyUp(KeyCode.T)) { TakeDamage(0.5f); }
    }

    void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / HealthSystem.getMaxHealth();
        Debug.Log("Ouch Level:" + healthAmount);
        if (healthAmount <= 0)
        {
            // Implement other stuff
            Debug.Log("HOW'D YOU DIE ITS A DEV ENV?!?!?!");
        }
    }

    void Heal(float healthIncrease)
    {
        healthAmount += healthIncrease;
        healthAmount = Mathf.Clamp(healthAmount, 0, HealthSystem.getMaxHealth());
        healthBar.fillAmount = healthAmount / HealthSystem.getMaxHealth();
        Debug.Log("Player Healed:" + healthAmount);
    }
}
