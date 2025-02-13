using UnityEngine;
using UnityEngine.UI;

public class textpop : MonoBehaviour
{
    public float popupDuration = 0.5f; // Duration for popup animation
    public Button triggerButton; // The button that triggers the effect
    private Vector3 originalScale; // Store the original scale
    private bool isPopupActive = false; // Track state

    private void Start()
    {
        originalScale = transform.localScale; // Store initial scale
        transform.localScale = Vector3.zero; // Start hidden

        if (triggerButton != null)
        {
            triggerButton.onClick.AddListener(() => {
                AnimateButton(triggerButton.gameObject);
                TogglePopup();
            });
        }
    }

    public void TogglePopup()
    {
        if (isPopupActive)
        {
            HidePopup();
        }
        else
        {
            ShowPopup();
        }
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, originalScale, popupDuration).setEaseOutBack();
        isPopupActive = true;
    }

    public void HidePopup()
    {
        LeanTween.scale(gameObject, Vector3.zero, popupDuration).setEaseInBack()
            .setOnComplete(() => gameObject.SetActive(false));
        isPopupActive = false;
    }

    private void AnimateButton(GameObject button)
    {
        Vector3 buttonOriginalScale = button.transform.localScale;

        LeanTween.scale(button, buttonOriginalScale * 1.1f, 0.1f)
            .setEaseOutQuad()
            .setOnComplete(() =>
                LeanTween.scale(button, buttonOriginalScale, 0.1f).setEaseInQuad()
            );
    }
}
