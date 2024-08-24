using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickCheckboxes : MonoBehaviour
{
    public Image tickedBox;
    public Image emailBox;
    public Image meetingBox;

    private void Start()
    {
        GameManager.emailsCount = 3;
    }
    private void Update()
    {
        if (GameManager.emailsCount == 3)
        {
            emailBox.sprite = tickedBox.sprite;
        }

        if (GameManager.meetingDone)
        {
            meetingBox.sprite = tickedBox.sprite;
        }
    }
}
