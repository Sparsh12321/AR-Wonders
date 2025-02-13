using UnityEngine;

public class disable : MonoBehaviour
{
    public float delay = 2f; // Time before disabling

    void Start()
    {
        Invoke("DisableObject", delay);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
