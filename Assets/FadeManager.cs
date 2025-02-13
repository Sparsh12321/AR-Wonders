using System.Collections;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Assign existing objects
    public float fadeDuration = 2.0f; // Adjust fade speed

    private void OnEnable()
    {
        fadein.OnEarthFadeComplete += EnableObjects;
    }

    private void OnDisable()
    {
        fadein.OnEarthFadeComplete -= EnableObjects;
    }

    private void Start()
    {
        // Disable all objects at the start
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }
    }

    private void EnableObjects()
    {
        Debug.Log("Earth fade-in complete. Enabling objects...");
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true); // Enable the object
            StartCoroutine(FadeInChildren(obj)); // Fade in all child materials
        }
    }

    private IEnumerator FadeInChildren(GameObject parentObj)
    {
        Renderer[] childRenderers = parentObj.GetComponentsInChildren<Renderer>(); // Get all child renderers

        foreach (Renderer renderer in childRenderers)
        {
            foreach (Material material in renderer.materials) // Handle multiple materials per renderer
            {
                SetMaterialToTransparent(material);
            }
        }

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            foreach (Renderer renderer in childRenderers)
            {
                foreach (Material material in renderer.materials)
                {
                    Color color = material.color;
                    color.a = newAlpha;
                    material.color = color;
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is fully 1 at the end
        foreach (Renderer renderer in childRenderers)
        {
            foreach (Material material in renderer.materials)
            {
                Color color = material.color;
                color.a = 1;
                material.color = color;
            }
        }
    }

    private void SetMaterialToTransparent(Material material)
    {
        material.SetFloat("_Mode", 3); // Set to Transparent Mode
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000; // Transparent queue
    }
}
