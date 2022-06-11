using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour
{
    public static float timeTracker = 0f;
    public static float maxTime = 60f * 5f;
    // public static float maxTime = 60f;
    public static float startTime = 8*60f;
    void FixedUpdate()
    {
        timeTracker += Time.deltaTime;
        BetweenScenesParams.currentEnergyLevel -= 1;
        if(timeTracker > maxTime) {
            SceneManager.LoadScene("EndingScreen");
        }
    }

    protected virtual void OnTimerFinished() {
        Debug.Log("Time finished!");
    }

    public static float getTimeLeft() {
        return maxTime - timeTracker;
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
