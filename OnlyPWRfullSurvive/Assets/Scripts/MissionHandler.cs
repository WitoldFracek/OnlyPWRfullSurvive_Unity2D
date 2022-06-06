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

        allOnTimeMissions.Add(new OnTimeMission(1, "A101", 10f) { Description = "W Cyberki"});
        allOnTimeMissions.Add(new OnTimeMission(2, "A201", 20f) { Description = "L Android"});

        allCollectMissions.Add(new CollectMission(5, 5, "CD") { Description = "Collect CDs"});

        allExevutableMissions.Add(new ExecutableMission(1, 60f) { Description = "Sprawozdanie cyberki"});
        allExevutableMissions.Add(new ExecutableMission(2, 90f) { Description = "Sprawozdanie hurtownia"});

        allTimeRestrictedMissions.Add(new TimeRestrictedMission(1, "A102", 30f) { Description = "Dokumenty dziekanat"});
    }

    public static void executeMissionForRoomNumber(string roomNumber) {
        var allRoomRelatedMissions = new List<RoomRelatedMission>();
        allRoomRelatedMissions.AddRange(allOnTimeMissions);
        allRoomRelatedMissions.AddRange(allTimeRestrictedMissions);
        foreach(var mission in allRoomRelatedMissions) {
            if(mission.roomNumber == roomNumber) {
                mission.setFinalisedIfAllowed();
            }
        }
    }
    public static void CollectOneItem(string itemTag) {
        var mission = allCollectMissions.FirstOrDefault(m => m.CollectableTag == itemTag);
        if(mission != null) {
            mission.AddOneItem();
        }
        
    }
    public static void ExecuteExecutableMission(int missionInx) {
        allExevutableMissions[missionInx].setFinalisedIfAllowed();
    }

    public static List<Mission> GetAllMissions()
    {
        List<Mission> allMissions = new List<Mission>();
        allMissions.AddRange(allOnTimeMissions);
        allMissions.AddRange(allCollectMissions);
        allMissions.AddRange(allTimeRestrictedMissions);
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

    public static void PassCollectable(string collectableTag)
    {
        foreach(var mission in allCollectMissions)
        {
            if(mission.CollectableTag == collectableTag)
            {
                mission.AddOneItem();
                Debug.Log("Item added " + collectableTag);
            }
        }
    }
}