using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    public Button emailButton;  // Reference to the email button
    public GameObject emailCheckButton;
    public Sprite emailCheckBoxButton; 
    public Button meetingButton;  // Reference to the email button
    public GameObject meetingCheckButton;
    void Start()
    {
        if (GameManager.emailsTaskCompleted)
        {
            emailButton.interactable = false;

            // Get the Image component and set its sprite to the new one
            Image image = emailCheckButton.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = emailCheckBoxButton;
            }
            else
            {
                Debug.LogError("No Image found on the emailCheckButton GameObject!");
            }
        }
        if (GameManager.meetingDone)
        {
            meetingButton.interactable = false;

            // Get the Image component and set its sprite to the new one
            Image image = meetingCheckButton.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = emailCheckBoxButton;
            }
            else
            {
                Debug.LogError("No Image found on the emailCheckButton GameObject!");
            }
        }
    }
}
