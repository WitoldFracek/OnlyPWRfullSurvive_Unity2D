public class Mission {
    public bool WasFinalised { get; protected set;}
    private int ectss;
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
        return canBeFinalised();
    }
}

public class TimeRestrictedMission : Mission {
    private float maxTimeToFinish;
    public TimeRestrictedMission(int ectss, float maxTimeToFinish) : base(ectss) {
        this.maxTimeToFinish = maxTimeToFinish;
    }

    override public bool canBeFinalised() {
        return TimeTracker.timeTracker <= maxTimeToFinish;
    }
}

public class OnTimeMission : Mission {
    public string roomNumber {get; private set;}
    private float timeToDoMission;
    private static float maxHowLateSec = 10f;
    public OnTimeMission(int ectss, string roomNumber, float maxTimeToFinish) : base(ectss) {
        this.timeToDoMission = maxTimeToFinish;
        this.roomNumber = roomNumber;
    }

    override public bool canBeFinalised() {
        return timeToDoMission <= TimeTracker.timeTracker &&
        TimeTracker.timeTracker <= timeToDoMission + maxHowLateSec;
    }

    override public bool isStillRelevant() {
        return TimeTracker.timeTracker <= timeToDoMission + maxHowLateSec;
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