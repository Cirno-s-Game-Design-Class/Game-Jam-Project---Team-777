using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Animator transition;
    public float loadDelay = 1f;
    public int timeInSeconds;
    public TextMeshProUGUI counter;

    float countdown;
    int minutes;
    int seconds;
    bool timerStart;

    private void Start()
    {
        transition = GetComponentInChildren<Animator>();
        countdown = timeInSeconds;
        StartCoroutine(TimerFade());
    }

    private void Update()
    {
        if (countdown > 0 & timerStart)
            TimeUpdate(Mathf.FloorToInt(countdown -= Time.deltaTime));
        else
            counter.text = "00:00";
    }

    private void TimeUpdate(int totalTime)
    {
        minutes = totalTime / 60;
        seconds = totalTime % 60;
        counter.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    IEnumerator TimerFade()
    {
        yield return new WaitForSeconds(loadDelay);
        transition.SetTrigger("BeginCrossfade");
        timerStart = true;
    }
}
