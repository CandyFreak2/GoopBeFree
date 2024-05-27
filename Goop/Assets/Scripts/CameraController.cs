using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float fallSpeedMultiplier = 2f;
    [SerializeField] private Vector2 offset;

    public Transform player;

    private void FixedUpdate() {
        Vector3 targetPos = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10f);
        float speed = followSpeed;

        if (player.GetComponent<Rigidbody2D>().velocity.y < 0) {
            speed *= fallSpeedMultiplier;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }
}
