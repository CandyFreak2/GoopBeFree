using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    //public GameOverScript gameOver;

    void Start()
    {
        
        //gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update healthAmount in each frame
        //float healthAmount = HealthSystem.GetCurrentHealth();

        if (Input.GetKeyUp(KeyCode.H)) { Heal(0.5f); }
        if (Input.GetKeyUp(KeyCode.T)) { TakeDamage(0.5f); }
    }

    void TakeDamage(float damage)
    {
        float healthAmount = HealthSystem.GetCurrentHealth();
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / HealthSystem.GetMaxHealth();
        Debug.Log("Ouch Level:" + healthAmount);

        if (healthAmount <= 0)
        {
            Debug.Log("HOW'D YOU DIE ITS A DEV ENV?!?!?!");
            //gameOver.Setup();
        }
    }

    void Heal(float healthIncrease)
    {
        float healthAmount = HealthSystem.GetCurrentHealth();
        healthAmount += healthIncrease;
        healthAmount = Mathf.Clamp(healthAmount, 0, HealthSystem.GetMaxHealth());
        healthBar.fillAmount = healthAmount / HealthSystem.GetMaxHealth();
        Debug.Log("Player Healed:" + healthAmount);
    }
}
