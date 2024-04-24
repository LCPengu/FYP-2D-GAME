using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    enum TimerType { Countdown, Stopwatch }
    string textTime;

    [SerializeField] private TimerType timerType;
    [SerializeField] private float timeToDisplay = 60.0f;

    private bool isRunning;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Event_Manger.TimerStart += EventMangerOnTimerStart;
        Event_Manger.TimerStop += EventMangerOnTimerStop;
        Event_Manger.TimerUpdate += EventMangerOnTimerUpdate;
    }

    private void OnDisable()
    {
        Event_Manger.TimerStart -= EventMangerOnTimerStart;
        Event_Manger.TimerStop -= EventMangerOnTimerStop;
        Event_Manger.TimerUpdate -= EventMangerOnTimerUpdate;
    }


    private void EventMangerOnTimerStart() => isRunning = true;
    private void EventMangerOnTimerStop() => isRunning = false;
    private void EventMangerOnTimerUpdate(float time) => timeToDisplay += time;

    private void Update()
    {
        if (!isRunning) return;
        if (timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            Event_Manger.OnTimerStop();
            return;
        }
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
        textTime = timerText.text;
    }

public string GetTime()
    {
        return textTime;
    }
}
