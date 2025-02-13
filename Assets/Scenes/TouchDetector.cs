using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    public MonoBehaviour tajrotate; // Assign the rotation script in the Inspector

    void Update()
    {
        if (Input.touchCount > 0) // Check if there is any touch
        {
            tajrotate.enabled = false; // Disable the rotation script
        }
    }
}
