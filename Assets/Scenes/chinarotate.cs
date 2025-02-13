using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chinarotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust speed in Inspector

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
