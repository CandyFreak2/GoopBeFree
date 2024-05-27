using UnityEngine;

public class GoopController : MonoBehaviour
{
    /*public float playerSpeed; 
    private static bool isFacingRight, isJumping, isGrounded;
    private static float chargeTime, maxChargeTime, timeSincePrevCharge;
    private float minJump, maxJump;
    private float fallMultiplier = 2.5f, lowFallMultipler = 2.0f;*/

    public GoopCharacters.GoopCharacter character;
    public SpriteRenderer sprite;

    void Start()
    {
        character = (GoopCharacters.GoopCharacter) PlayerPrefs.GetInt("GoopCharacter");
    }

    void Update()
    {
        switch (character)
        {
            case GoopCharacters.GoopCharacter.GOOP:
                sprite.color = Color.green;
                break;
            case GoopCharacters.GoopCharacter.GOOPERSON:
                sprite.color = Color.white;
                break;
            case GoopCharacters.GoopCharacter.GOOPORIA:
                sprite.color = Color.cyan;
                break;
            case GoopCharacters.GoopCharacter.GOOPINGTON:
                sprite.color = Color.yellow;
                break;
            case GoopCharacters.GoopCharacter.GOOBERTA:
                sprite.color = Color.red;
                break;
            case GoopCharacters.GoopCharacter.GOOELLE:
                sprite.color = Color.gray;
                break;
            case GoopCharacters.GoopCharacter.OLD_MAN_GOOP:
                sprite.color = Color.blue;
                break;
            case GoopCharacters.GoopCharacter.THE_RAT_KING:
                sprite.color = Color.black;
                break;
            case GoopCharacters.GoopCharacter.GOOPETTE:
                sprite.color = Color.magenta;
                break;
        }
    }
}
