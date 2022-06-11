using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MissionHandler {
    public static List<OnTimeMission> allOnTimeMissions;
    public static List<CollectMission> allCollectMissions;
    public static List<TimeRestrictedMission> allTimeRestrictedMissions;
    public static List<ExecutableMission> allExevutableMissions;

    public static List< Mission> getAllMissions(bool relevant=true) {
        var missionList = new List<Mission>();
        foreach (var mission in GetAllMissions()) {
            if (mission.isStillRelevant() == relevant) {
                missionList.Add(mission);
            }
        }
        return missionList;
    }

    public static bool areMissionsSetup(){
        return allCollectMissions != null;
    }

    public static int GetCurrentECTSCount() {
        var count = 0;
        foreach (var mission in GetAllMissions()) {
            if(mission.WasFinalised && mission.GetType() != typeof(CollectMission)) {
                count += mission.GetECTSPoints();
            }
            else if (mission.GetType() == typeof(CollectMission)) {
                count += mission.GetECTSPoints();
            }
        }
        return count;
    }
    
    public static void setLevel1Missions() {
        allOnTimeMissions = new List<OnTimeMission>();
        allCollectMissions = new List<CollectMission>();
        allExevutableMissions = new List<ExecutableMission>();
        allTimeRestrictedMissions = new List<TimeRestrictedMission>();

        allOnTimeMissions.Add(new OnTimeMission(9, "101", "A1", 60f * 2f) { Description = "Lecture Data warehouse"});
        allCollectMissions.Add(new CollectMission(5, 5, "CD") { Description = "Collect CDs"});
        allExevutableMissions.Add(new ExecutableMission(9, 60f * 2f) { Description = "Report Data warehouse"});
        allTimeRestrictedMissions.Add(new TimeRestrictedMission(7, "102", "Dean", 60f * 4f) { Description = "Dean's office paperwork"});
    }

    public static void setLevel2Missions() {
        allOnTimeMissions = new List<OnTimeMission>();
        allCollectMissions = new List<CollectMission>();
        allExevutableMissions = new List<ExecutableMission>();
        allTimeRestrictedMissions = new List<TimeRestrictedMission>();

        allOnTimeMissions.Add(new OnTimeMission(5, "104", "A1", 60f*1f) { Description = "Lecture Microsoft admin"});
        allOnTimeMissions.Add(new OnTimeMission(5, "104", "C13", 60f*4f) { Description = "Laboratory Android"});

        allCollectMissions.Add(new CollectMission(5, 5, "PENDRIVE") { Description = "Collect pendrives"});

        allExevutableMissions.Add(new ExecutableMission(5, 30f) { Description = "Report Cybersecurity"});
        allExevutableMissions.Add(new ExecutableMission(5, 60f) { Description = "App Android"});

        allTimeRestrictedMissions.Add(new TimeRestrictedMission(5, "101", "Dean", 60f * 4f) { Description = "Sticker student ID"});
    }

    public static void setLevel3Missions() {
        allOnTimeMissions = new List<OnTimeMission>();
        allCollectMissions = new List<CollectMission>();
        allExevutableMissions = new List<ExecutableMission>();
        allTimeRestrictedMissions = new List<TimeRestrictedMission>();

        allOnTimeMissions.Add(new OnTimeMission(1, "105", "A1", 60f) { Description = "Lecture Microsoft admin"});
        allOnTimeMissions.Add(new OnTimeMission(2, "103", "C13", 60f*2f) { Description = "Laboratory Android"});
        allOnTimeMissions.Add(new OnTimeMission(1, "103", "A1", 60f*3f) { Description = "Lecture Data warehouse"});
        allOnTimeMissions.Add(new OnTimeMission(2, "102", "C13", 60f*4f) { Description = "Laboratory .NET"});

        allCollectMissions.Add(new CollectMission(5, 5, "CIRCUT_BOARD") { Description = "Collect Circut boards"});

        allExevutableMissions.Add(new ExecutableMission(1, 160f) { Description = "Code checkers MIN-MAX"});
        allExevutableMissions.Add(new ExecutableMission(2, 90f) { Description = "Report "});
        allExevutableMissions.Add(new ExecutableMission(2, 190f) { Description = "Website .NET"});

        allTimeRestrictedMissions.Add(new TimeRestrictedMission(6, "103", "Dean", 60f * 2.5f) { Description = "Internship paperwork"});
    }

    public static void executeMissionForRoomNumber(string roomNumber, string buildingName) {
        var allRoomRelatedMissions = new List<RoomRelatedMission>();
        allRoomRelatedMissions.AddRange(allOnTimeMissions);
        allRoomRelatedMissions.AddRange(allTimeRestrictedMissions);
        foreach(var mission in allRoomRelatedMissions) {
            if(mission.roomNumber == roomNumber && mission.buildingName == buildingName) {
                mission.setFinalisedIfAllowed();
            }
        }
    }
    // public static void CollectOneItem(string itemTag) {
    //     var mission = allCollectMissions.FirstOrDefault(m => m.CollectableTag == itemTag);
    //     if(mission != null) {
    //         mission.AddOneItem();
    //     }
        
    // }
    public static void ExecuteExecutableMission(int missionInx) {
        allExevutableMissions[missionInx].setFinalisedIfAllowed();
    }

    public static List<Mission> GetAllMissions()
    {
        List<Mission> allMissions = new List<Mission>();
        if(allOnTimeMissions != null)
            allMissions.AddRange(allOnTimeMissions);
        if (allTimeRestrictedMissions != null)
            allMissions.AddRange(allTimeRestrictedMissions);
        if (allCollectMissions != null)
            allMissions.AddRange(allCollectMissions);
        if (allExevutableMissions != null)
            allMissions.AddRange(allExevutableMissions);
        return allMissions;
    }

    public static List<Mission> GetAllUnfinishedMissions()
    {
        return GetAllMissions().FindAll(m => !m.WasFinalised).ToList();
    }

    public static List<Mission> GetAllImpossibleToFinishMissions()
    {
        return GetAllMissions().FindAll(m => !m.canBeFinalised()).ToList();
    }

    public static int GetUnfinishedMissionsCount() {
        int counter = 0;
        List<Mission> allMissions = GetAllMissions();
        foreach(var mission in allMissions) {
            if(!mission.WasFinalised) {
                counter += 1;
            }
        }
        return counter;
    }

    public static void PassCollectable(CollectableHandler collectable)
    {
        foreach(var mission in allCollectMissions)
        {
            if(mission.CollectableTag == collectable.collectableTag)
            {
                mission.AddOneItem(collectable.id);
            }
        }
    }
}