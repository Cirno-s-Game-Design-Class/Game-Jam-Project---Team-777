using UnityEngine;
using UnityEngine.UI; // Required for manipulating UI components like buttons

public class ToggleObjects : MonoBehaviour
{
    public Button exit;
    public GameObject[] objectsToToggle; // Array of objects to toggle
    public Button[] buttons; // Corresponding buttons for each object
    private int lastSelectedIndex = -1; // Index of the last selected object
    public GameManager gameManager;
    private void Update()
    {
        if (GameManager.emailsCount == 3)
        {
            exit.interactable = true;
        }
    }

    // Method to show only one object and hide others
    public void ShowOnlyObject(int index)
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(i == index);
        }
        lastSelectedIndex = index; // Update the last selected index
    }

    // Method to be called when the send button is pressed
    public void HideSelectedObject()
    {
        if (lastSelectedIndex != -1 && lastSelectedIndex < buttons.Length)
        {
            Debug.Log("Disabling object at index: " + lastSelectedIndex);
            objectsToToggle[lastSelectedIndex].SetActive(false);
            buttons[lastSelectedIndex].interactable = false;
            GameManager.Instance.CountUpEmail(); 
            Debug.Log("Is button now interactable? " + buttons[lastSelectedIndex].interactable);
            lastSelectedIndex = -1;
        }
        else
        {
            Debug.Log("Invalid lastSelectedIndex: " + lastSelectedIndex);
        }
    }
}