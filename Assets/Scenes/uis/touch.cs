using UnityEngine;

public class touch : MonoBehaviour
{
    // Sensitivity for rotation adjustments.
    public float rotationSpeed = 0.2f;

    void Update()
    {
        // Handle one-finger input for X and Y axis rotation.
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                // Get the change in position since the last frame.
                Vector2 delta = touch.deltaPosition;

                // Apply rotation:
                //   - Vertical movement rotates around the X-axis.
                //   - Horizontal movement rotates around the Y-axis.
                // Note: We use Space.World so that the rotations occur in world space.
                transform.Rotate(delta.y * rotationSpeed, -delta.x * rotationSpeed, 0, Space.World);
            }
        }
        // Handle two-finger input for Z axis (twist) rotation.
        else if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the positions of the touches in the previous frame.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Calculate the angle between the touches in the previous frame.
            float prevAngle = Mathf.Atan2(touchOnePrevPos.y - touchZeroPrevPos.y,
                                          touchOnePrevPos.x - touchZeroPrevPos.x) * Mathf.Rad2Deg;

            // Calculate the angle between the touches in the current frame.
            float currentAngle = Mathf.Atan2(touchOne.position.y - touchZero.position.y,
                                             touchOne.position.x - touchZero.position.x) * Mathf.Rad2Deg;

            // Determine the change in angle.
            float angleDelta = currentAngle - prevAngle;

            // Rotate around the Z-axis based on the twist gesture.
            transform.Rotate(0, 0, -angleDelta * rotationSpeed, Space.World);
        }
    }
}
