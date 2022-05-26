using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRangeBehavior : PlayerInRange
{
    [SerializeField]
    private float timeToEnter;
    private static float maxHowLateSec = 10f;

    override protected void whenInRange() {
        // Debug.Log(timeToEnter + " " + TimeTracker.timeTracker + " " + (timeToEnter + maxHowLateSec));
        if(timeToEnter <= TimeTracker.timeTracker && TimeTracker.timeTracker <= timeToEnter + maxHowLateSec) {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    override protected void whenOutOfRange() {
        if(timeToEnter <= TimeTracker.timeTracker && TimeTracker.timeTracker <= timeToEnter + maxHowLateSec) {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
