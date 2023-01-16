using UnityEngine;

public class AutoMoveObstacle : MonoBehaviour
{
    public Vector3 moveDirection; // The direction the obstacle should move in
    public float moveSpeed; // The speed at which the obstacle should move
    public float moveDistance; // The distance the obstacle should move before reversing direction
    public bool loop; // Whether or not the obstacle should loop its movement

    private Vector3 startPosition; // The obstacle's starting position
    private float currentDistance; // The distance the obstacle has moved from its start position
    private bool movingForward; // Whether the obstacle is currently moving forward or not

    void Start()
    {
        startPosition = transform.position; // Store the obstacle's starting position
        currentDistance = 0f;
        movingForward = true;
    }

    void Update()
    {
        if (movingForward)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            currentDistance += moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= moveDirection * moveSpeed * Time.deltaTime;
            currentDistance -= moveSpeed * Time.deltaTime;
        }

        if (currentDistance >= moveDistance)
        {
            if (loop)
            {
                currentDistance = 0f;
                movingForward = !movingForward;
            }
            else
            {
                currentDistance = moveDistance;
                movingForward = false;
            }
        }
        else if (currentDistance <= 0f && !movingForward)
        {
            if (loop)
            {
                currentDistance = moveDistance;
                movingForward = !movingForward;
            }
            else
            {
                currentDistance = 0f;
                movingForward = true;
            }
        }
    }
}
