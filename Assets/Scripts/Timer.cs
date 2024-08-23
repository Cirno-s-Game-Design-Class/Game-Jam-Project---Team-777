using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timeInSeconds;
    public TextMeshProUGUI counter;

    public float countdown;
    int minutes;
    int seconds;

    private void Start()
    {
        countdown = timeInSeconds;
    }

    private void Update()
    {
        if (countdown > 0)
        {
            int totalTime = Mathf.FloorToInt(countdown -= Time.deltaTime);
            minutes = totalTime / 60;
            seconds = totalTime % 60;
            counter.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
        else
        {
            counter.text = "00:00";
        }
    }
}
