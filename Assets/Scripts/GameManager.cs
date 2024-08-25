using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int emailsCount = 0;
    public static bool emailsTaskCompleted = false;
    public static bool meetingDone = false;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CountUpEmail()
    {
        if (emailsCount < 3)
        {
            emailsCount++;
            Debug.Log("Emails sent: " + emailsCount);
            if (emailsCount >= 3)  // Check if task is completed
            {
                emailsTaskCompleted = true;  // Set the task as completed
            }
        }
    }
}