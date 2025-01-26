using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;    // The object the camera will follow
    public float minX = 1f;   // Minimum X position
    public float maxX = 58.14f;    // Maximum X position
    public float smoothSpeed = 0.125f; // Smoothing speed

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position, keeping Y fixed
            Vector3 desiredPosition = new Vector3(target.position.x, 0, transform.position.z);

            // Clamp the X position between minX and maxX
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
    }
