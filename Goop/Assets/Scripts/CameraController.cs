using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;

    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
