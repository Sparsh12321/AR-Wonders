using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public fadein fadeScript; // Assign the fade-in script in the Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("earth")) // Ensure Earth has the tag "Earth"
        {
            Debug.Log("Rays hit Earth - Triggering FadeIn");
            fadeScript.StartFadeIn();
        }
    }
}
