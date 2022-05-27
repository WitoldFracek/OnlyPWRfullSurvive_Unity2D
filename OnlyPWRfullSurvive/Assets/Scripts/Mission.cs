public class Mission {
    public bool WasFinalised { get; protected set;}
    public int ectss {get; private set;}
    public string Description { get; set; }

    public Mission(int ectss) {
        WasFinalised = false;
        this.ectss = ectss;
    }

    public void setFinalisedIfAllowed() {
        if(canBeFinalised()) {
            WasFinalised = true;
        }
    }

    public virtual bool canBeFinalised() {
        return true;
    }

    public virtual bool isStillRelevant() {
        if (WasFinalised) return false;
        return canBeFinalised();
    }

    public override string ToString()
    {
        var prevText = ectss + " ECTS - ";
        if(WasFinalised) {
            prevText += "DONE ";
        }
        return prevText + Description;
    }
}

public class RoomRelatedMission : Mission {
    public string roomNumber {get; private set;}

    public RoomRelatedMission(int ectss, string roomNumber) : base(ectss) {
        this.roomNumber = roomNumber;
    }
}

public class TimeRestrictedMission : RoomRelatedMission {
    private float maxTimeToFinish;
    public TimeRestrictedMission(int ectss, string roomNumber, float maxTimeToFinish) : base(ectss, roomNumber) {
        this.maxTimeToFinish = maxTimeToFinish;
    }

    override public bool canBeFinalised() {
        return TimeTracker.timeTracker <= maxTimeToFinish;
    }

    public override string ToString()
    {
        return "MAX " + TimeTracker.GetTimePretty(maxTimeToFinish) 
        + " - " + roomNumber + " - " + base.ToString();
    }
}

public class OnTimeMission : RoomRelatedMission {
    private float timeToDoMission;
    private static float maxHowLateSec = 5f;
    public OnTimeMission(int ectss, string roomNumber, float maxTimeToFinish) : base(ectss, roomNumber) {
        this.timeToDoMission = maxTimeToFinish;
    }

    override public bool canBeFinalised() {
        return timeToDoMission <= TimeTracker.timeTracker &&
        TimeTracker.timeTracker <= timeToDoMission + maxHowLateSec;
    }

    override public bool isStillRelevant() {
        if (WasFinalised) return false;
        return TimeTracker.timeTracker <= timeToDoMission + maxHowLateSec;
    }

    public override string ToString()
    {
        return "ON  " + TimeTracker.GetTimePretty(timeToDoMission) 
        + " - " + roomNumber + " - " + base.ToString();
    }
}

public class CollectMission: Mission {
    
    public string CollectableTag { get; private set; }
    private int maxCount;
    private int currentCount;

    public CollectMission(int ects, int itemCount, string itemTag): base(ects) {
        this.CollectableTag = itemTag;
        this.maxCount = itemCount;
        this.currentCount = 0;
    }

    public void AddOneItem() {
        currentCount += 1;
        // if(currentCount >= maxCount) {
        //     WasFinalised = true;
        // }
    }

    override public bool isStillRelevant() {
        return currentCount < maxCount;
    }

}

public class ExecutableMission: Mission {

    public float Duration { get; protected set; }

    public ExecutableMission(int ects, float duration): base(ects) {
        Duration = duration;
    }

    override public bool canBeFinalised() {
        return TimeTracker.timeTracker + Duration < TimeTracker.maxTime;
    }

}