using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public string sceneToLoad; // Set scene name in Inspector
    public float delay = 2f; // Delay time in seconds

    void Start()
    {
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name not set!");
        }
    }
}
