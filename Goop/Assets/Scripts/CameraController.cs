using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float fallSpeedMultiplier;
    public Transform player;
    public Vector2 offset;

    void Update()
    {
        Vector3 newCameraPos = new(player.position.x + offset.x, player.position.y + offset.y, -10);
        if (player.GetComponent<Rigidbody2D>().velocity.y < 0) {
            transform.position = Vector3.Lerp(transform.position, newCameraPos, fallSpeedMultiplier * Time.deltaTime);
        } else {
            transform.position = Vector3.Lerp(transform.position, newCameraPos, followSpeed * Time.deltaTime);
        }
    }
}
