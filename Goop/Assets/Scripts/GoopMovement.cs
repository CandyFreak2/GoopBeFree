using UnityEngine;

public class GoopMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private static bool isFacingRight = true, isJumping = false, isGrounded = false, isGoopDead = false;
    private static float chargeTime = 0.0f, maxChargeTime = 5.0f;
    private float minJumpForce = 2.5f, maxJumpForce = 12.0f, timeSinceLastCharge = 0.0f;
    private const float chargeTimeDecayDelay = 3.0f;

    public float playerSpeed = 3.5f, fallMultiplier = 2.5f, lowJumpMultiplier = 2.0f;

    [SerializeField]public HealthSystem healthSystem;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is alive before allowing movement
        if (!isGoopDead)
        {
            // Movement logic
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            if (horizontalMovement != 0)
            {
                Flip(horizontalMovement > 0);
            }

            // Jump logic
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
            }

            if (Input.GetKey(KeyCode.Space) && isJumping && chargeTime < maxChargeTime)
            {
                chargeTime += Time.deltaTime;
                timeSinceLastCharge = 0.0f;
            }

            if (Input.GetKeyUp(KeyCode.Space) && isJumping)
            {
                Jump();
            }

            if (!Input.GetKey(KeyCode.Space) && chargeTime > 0)
            {
                timeSinceLastCharge += Time.deltaTime;
                if (timeSinceLastCharge >= chargeTimeDecayDelay)
                {
                    chargeTime -= Time.deltaTime;
                    chargeTime = Mathf.Max(chargeTime, 0.0f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // Only move if the player is alive
        if (!isGoopDead)
        {
            // Movement logic
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector2(horizontalMovement * playerSpeed, rigidBody.velocity.y);

            // Jump logic
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.fixedDeltaTime * Vector2.up;
            }
            else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space) && !isGrounded)
            {
                rigidBody.velocity += (lowJumpMultiplier - 1) * Physics2D.gravity.y * Time.fixedDeltaTime * Vector2.up;
            }
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void Flip(bool right)
    {
        if (isFacingRight != right)
        {
            isFacingRight = right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        float normalizedCharge = Mathf.Clamp01(chargeTime / maxChargeTime);
        float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, normalizedCharge);

        // RESETS VELOCITY
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
        chargeTime = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public float GetChargeTime() { return chargeTime; }

    public float GetMaxChargeTime() { return maxChargeTime; }

    public bool IsJumping() { return isJumping; }

    public bool IsOnGround() { return isGrounded; }

    public void SetIsGoopDead(bool isDead)
    {
       isGoopDead = isDead;
    }
}