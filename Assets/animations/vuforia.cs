using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vuforia : MonoBehaviour
{
    private ObserverBehaviour trackableBehaviour; // ✅ Updated to ObserverBehaviour for newer Vuforia versions
    public Animator objectAnimator; // Assign this in the Inspector

    void Start()
    {
        trackableBehaviour = GetComponent<ObserverBehaviour>(); // ✅ Use ObserverBehaviour (New API)
        if (trackableBehaviour)
        {
            trackableBehaviour.OnTargetStatusChanged += OnTrackableStateChanged;
        }
    }

    private void OnDestroy()
    {
        if (trackableBehaviour)
        {
            trackableBehaviour.OnTargetStatusChanged -= OnTrackableStateChanged;
        }
    }

    private void OnTrackableStateChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log("Object Tracked - Starting Animation");
            objectAnimator.SetTrigger("StartAnimation"); // Use an animation trigger
        }
        else
        {
            Debug.Log("Object Lost - Stopping Animation");
            objectAnimator.SetTrigger("StopAnimation"); // Optional: Reset animation
        }
    }
}
