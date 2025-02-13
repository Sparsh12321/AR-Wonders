using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textswitch : MonoBehaviour
{
    public TextMeshProUGUI[] textObjects; // Array of text objects
    public Button forwardButton; // Button to go forward
    public Button backButton; // Button to go back
    private int currentIndex = 0; // Tracks current text index

    private void Start()
    {
        // Hide all texts initially except the first one
        for (int i = 0; i < textObjects.Length; i++)
        {
            textObjects[i].gameObject.SetActive(i == 0);
        }

        // Assign button events
        forwardButton.onClick.AddListener(NextText);
        backButton.onClick.AddListener(PreviousText);

        // Update button visibility
        UpdateButtonStates();
    }

    public void NextText()
    {
        if (currentIndex < textObjects.Length - 1)
        {
            textObjects[currentIndex].gameObject.SetActive(false);
            currentIndex++;
            textObjects[currentIndex].gameObject.SetActive(true);
            UpdateButtonStates();
        }
    }

    public void PreviousText()
    {
        if (currentIndex > 0)
        {
            textObjects[currentIndex].gameObject.SetActive(false);
            currentIndex--;
            textObjects[currentIndex].gameObject.SetActive(true);
            UpdateButtonStates();
        }
    }

    private void UpdateButtonStates()
    {
        backButton.interactable = currentIndex > 0;
        forwardButton.interactable = currentIndex < textObjects.Length - 1;
    }
}
