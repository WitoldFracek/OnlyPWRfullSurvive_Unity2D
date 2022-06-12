using System.Linq;
using System.Collections.Generic;

public class Mission {
    private static int maxNameLength = 25;
    public bool WasFinalised { get;  set;}
    public int ectss {get; private set;}
    public string Description { get; set; }

    public Mission(int ectss) {
        WasFinalised = false;
        this.ectss = ectss;
    }

    public virtual bool setFinalisedIfAllowed() {
        if(canBeFinalised()) {
            WasFinalised = true;
            return true;
        }
        return false;
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
        var prevText = Description.PadRight(maxNameLength) + " ECTS " + ectss;
        if(WasFinalised) {
            prevText += "DONE ";
        }
        return prevText;
    }

    public virtual int GetECTSPoints() {
        return ectss;
    }
}

public class RoomRelatedMission : Mission {
    public string roomNumber {get; private set;}
    public string buildingName {get; private set;}

    public RoomRelatedMission(int ectss, string roomNumber, string buildingName) : base(ectss) {
        this.roomNumber = roomNumber;
        this.buildingName = buildingName;
    }
}

public class TimeRestrictedMission : RoomRelatedMission {
    private float maxTimeToFinish;
    public float TimeToDoMission
    {
        get { return maxTimeToFinish; }
    }
    public bool SoundStarted { get; set; } = false;
    public TimeRestrictedMission(int ectss, string roomNumber, string buildingName, float maxTimeToFinish) : base(ectss, roomNumber, buildingName) {
        this.maxTimeToFinish = maxTimeToFinish;
    }

    override public bool canBeFinalised() {
        return TimeTracker.timeTracker <= maxTimeToFinish;
    }

    public override string ToString()
    {
        return base.ToString() + " MAX " + TimeTracker.GetTimePretty(maxTimeToFinish) 
        + " - " + buildingName + " " + roomNumber;
    }
}

public class OnTimeMission : RoomRelatedMission {
    private float timeToDoMission;
    public float TimeToDoMission { get { return timeToDoMission; }
         }
    public bool SoundStarted { get; set; } = false;
    private static float maxHowLateSec = 5f;
    public OnTimeMission(int ectss, string roomNumber, string buildingName, float maxTimeToFinish) : base(ectss, roomNumber, buildingName) {
        this.timeToDoMission = maxTimeToFinish + 15f;
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
        return base.ToString() + " ON  " + TimeTracker.GetTimePretty(timeToDoMission) 
        + " - " + buildingName + " " + roomNumber;
    }
}

public class CollectMission: Mission {
    
    public string CollectableTag { get; private set; }
    public List<string> collectedIds { get; private set; }
    private int maxCount;
    private int currentCount;

    public CollectMission(int ects, int itemCount, string itemTag): base(ects) {
        this.CollectableTag = itemTag;
        this.maxCount = itemCount;
        this.currentCount = 0;
        collectedIds = new List<string>();
    }

    public void AddOneItem(string id) {
        currentCount += 1;
        if(id != "") {
            collectedIds.Add(id);
        }
    }

    override public bool isStillRelevant() {
        return currentCount < maxCount;
    }

    override public int GetECTSPoints() {
        return ectss*currentCount/maxCount;
    }

    public override string ToString()
    {
        return base.ToString() + " (" + GetECTSPoints() + $"/{ectss})" ;
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

    public override string ToString()
    {
        return base.ToString() + " " + Duration + " min" ;
    }

    public string FileDescription() {
        return Description + "\n" + Duration + " min" + "\n" + ectss + " ECTS";
    }

    public override bool setFinalisedIfAllowed() {
        if(canBeFinalised()) {
            WasFinalised = true;
            TimeTracker.timeTracker += Duration;
            return true;
        }
        return false;
    }
}