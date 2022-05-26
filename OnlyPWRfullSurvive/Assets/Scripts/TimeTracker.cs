using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public static float timeTracker = 0f;
    void FixedUpdate()
    {
        timeTracker += Time.deltaTime;
    }

    protected virtual void OnTimerFinished() {
        Debug.Log("Time finished!");
    }
}