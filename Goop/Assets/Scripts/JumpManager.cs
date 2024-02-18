using UnityEngine;
using UnityEngine.UI;

public class JumpManager : MonoBehaviour
{
    public Image jumpBar;
    private GoopMovement goopMovement;

    void Start()
    {
        GameObject goopObject = GameObject.FindWithTag("Player");
        if (goopObject != null)
        {
            if (!goopObject.TryGetComponent(out goopMovement))
            {
                Debug.LogError("GoopMovement component not found on the object with tag 'Player'");
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'Player' not found");
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
        else
        {
            Debug.LogWarning("GoopMovement component is not initialized.");
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