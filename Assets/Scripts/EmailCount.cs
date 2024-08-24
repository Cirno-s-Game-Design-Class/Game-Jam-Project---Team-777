using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailCount : MonoBehaviour
{
    public List<Image> emailPips;
    Color32 orange = new Color32(255, 124, 0, 255);

    private void Awake()
    {
        if (GameManager.emailsCount == 1)
        {
            emailPips[1].color = orange;
        }

        if (GameManager.emailsCount == 2)
        {
            emailPips[1].color = orange;
            emailPips[2].color = orange;
        }

        if (GameManager.emailsCount == 3)
        {
            emailPips[1].color = orange;
            emailPips[2].color = orange;
            emailPips[3].color = orange;
        }
    }
}
