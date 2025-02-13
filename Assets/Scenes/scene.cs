using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // Add this line

public class scene : MonoBehaviour
{
    public string sceneToLoad; // Set the scene name in Inspector
    public Animator transition; // Assign Animator in Inspector
    public float transitionTime = 1f; // Adjust as needed

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            HandleInput(Input.GetTouch(0).position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
    }

    void HandleInput(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Tapped " + gameObject.name + ", playing animation.");
                StartCoroutine(LoadSceneWithAnimation());
            }
        }
    }

    IEnumerator LoadSceneWithAnimation()
    {
        if (transition != null)
        {
            transition.SetTrigger("Start"); // Ensure you have a trigger named "Start" in Animator
            yield return new WaitForSeconds(transitionTime);
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
