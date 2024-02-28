using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    public Transform player;
    public Vector2 offset;

    void Update()
    {
        Vector3 newCameraPos = new(player.position.x + offset.x, player.position.y + offset.y, -10);
        transform.position = Vector3.Slerp(transform.position, newCameraPos, followSpeed * Time.deltaTime);
    }
}
