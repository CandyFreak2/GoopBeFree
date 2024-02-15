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
                Debug.LogError("GoopMovement component not found on the object with tag 'GoopPlayer'");
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'GoopPlayer' not found");
        }
    }

    void Update()
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

    void ChargeTimeBar()
    {
        float jumpAmount = goopMovement.GetChargeTime();
        float maxChargeTime = goopMovement.GetMaxChargeTime();

        float fillAmount = Mathf.Clamp01(jumpAmount / maxChargeTime);
        jumpBar.fillAmount = fillAmount;
    }
}
