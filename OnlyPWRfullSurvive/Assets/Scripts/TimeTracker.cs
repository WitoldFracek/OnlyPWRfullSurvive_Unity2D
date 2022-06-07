using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public static float timeTracker = 0f;
    public static float maxTime = 720f;
    public static float startTime = 8*60f;
    void FixedUpdate()
    {
        timeTracker += Time.deltaTime;
        BetweenScenesParams.currentEnergyLevel -= 1;
    }

    protected virtual void OnTimerFinished() {
        Debug.Log("Time finished!");
    }

    public static string GetTimePretty(float time)
    {
        time += startTime;
        int hour = (int)(time / 60);
        int minute = (int)(time - hour * 60);
        string zero = "";
        if(minute < 10)
        {
            zero = "0";
        }
        return $"{hour}:{zero}{minute}";
    }

    public static string GetCurrentTimePretty() {
        return GetTimePretty(timeTracker);
    }
}
