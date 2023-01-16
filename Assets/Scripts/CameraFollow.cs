using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 20f;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 startOffset;
    public float rotationSpeed = 10f;
    public float lookAheadDistance = 1.5f;
    public float minDistance = 5, maxDistance = 15;

    void Start()
    {
        // set initial camera position and rotation based on start offset
        transform.position = target.position + startOffset;
        transform.LookAt(target);
    }

    void Update()
    {
        // vector directed from the target to the camera
        Vector3 direction = transform.position - target.position;

        // clamp magnitude of the vector
        direction = Vector3.ClampMagnitude(direction, maxDistance);
        direction = Vector3.ClampMagnitude(direction, minDistance);

        // calculate the desired camera position
        Vector3 desiredPosition = target.position + offset + direction;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // rotate the camera to look at the target
        transform.LookAt(target);
    }
}
