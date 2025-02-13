using System;
using System.Collections;
using UnityEngine;

public class fadein : MonoBehaviour
{
    private Material material;
    private Color color;
    public float fadeDuration = 2.0f;
    public static event Action OnEarthFadeComplete; // Event triggered after fade-in

    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.HasProperty("_TintColor") ? material.GetColor("_TintColor") : material.GetColor("_Color");
        color.a = 0;
        SetMaterialAlpha(color.a);
    }

    public void StartFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            SetMaterialAlpha(newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetMaterialAlpha(1);

        // 🚀 Notify that Earth fade-in is done
        OnEarthFadeComplete?.Invoke();
    }

    private void SetMaterialAlpha(float alpha)
    {
        color.a = alpha;
        if (material.HasProperty("_TintColor"))
            material.SetColor("_TintColor", color);
        else
            material.SetColor("_Color", color);
    }
}
