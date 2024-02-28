using UnityEngine;
using UnityEngine.UI;

public class JumpManager : MonoBehaviour
{
    public Image jumpBar;
    [SerializeField] private GoopMovement goopMovement;

    void Start()
    {
        if (goopMovement == null)
        {
            Debug.LogError("GoopMovement component is not assigned");
        }
        else
        {
            Debug.Log("GoopMovement component is assigned");
        }
    }

    void Update()
    {
        if (goopMovement != null)
        {
            if (goopMovement.IsJumping())
            {
                ChargeTimeBar();
            }
            else
            {
                jumpBar.fillAmount = 0f;
            }
        }
    }

    void ChargeTimeBar()
    {
        if (jumpBar != null)
        {
            if (goopMovement != null)
            {
                float jumpAmount = goopMovement.GetChargeTime();
                float maxChargeTime = goopMovement.GetMaxChargeTime();

                float fillAmount = Mathf.Clamp01(jumpAmount / maxChargeTime);
                jumpBar.fillAmount = fillAmount;
            }
            else
            {
                Debug.LogWarning("GoopMovement component is not initialized.");
            }
        }
        else
        {
            Debug.LogWarning("jumpBar reference is null.");
        }
    }
}