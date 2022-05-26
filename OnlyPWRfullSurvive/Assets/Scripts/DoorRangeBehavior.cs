using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRangeBehavior : PlayerInRange
{
    [SerializeField]
    private string doorNumber;

    override protected void whenInRange() {
        MissionHandler.executeMissionForRoomNumber(doorNumber);
        // Debug.Log(timeToEnter + " " + TimeTracker.timeTracker + " " + (timeToEnter + maxHowLateSec));
        // if(timeToEnter <= TimeTracker.timeTracker && TimeTracker.timeTracker <= timeToEnter + maxHowLateSec) {
        //     gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        // }
        // else {
        //     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        // }
    }
}
