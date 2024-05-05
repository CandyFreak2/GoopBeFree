using UnityEngine;

public class GoopHealth : MonoBehaviour
{
    public float healthAmount = 10f;
    private GoopMovement goopMovement;

    void Start()
    {
        goopMovement = GetComponent<GoopMovement>();
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            Debug.Log("Player Health is 0");
            goopMovement.SetIsGoopDead(true);
        }
    }
}
