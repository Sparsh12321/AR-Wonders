using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backscript : MonoBehaviour
{
    public string sceneToLoad; // Set scene name in Inspector
    public Button button; // Assign button in Inspector

    void Start()
    {
        button.onClick.AddListener(LoadScene);
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
