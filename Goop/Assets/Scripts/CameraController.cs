using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float currentXPos;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentXPos, transform.position.y, transform.position.z), ref velocity, cameraSpeed * Time.deltaTime);
    }

    void TransitionToNewSection(Transform newSection) { 
        currentXPos = newSection.position.x;
    }
}
