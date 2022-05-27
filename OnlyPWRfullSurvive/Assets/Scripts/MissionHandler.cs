using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionHandler {
    public static List<OnTimeMission> allOnTimeMissions;
    public static List<CollectMission> allCollectMissions;
    public static List<TimeRestrictedMission> allTimeRestrictedMissions;
    public static List<ExecutableMission> allExevutableMissions;

    // public MissionHandler() {
    //     if (allOnTimeMissions == null) {
    //         setLevel1Missions();
    //     }
    // }
    
    public static void setLevel1Missions() {
        allOnTimeMissions = new List<OnTimeMission>();
        allOnTimeMissions.Add(new OnTimeMission(1, "A101", 10f) { Description = "Misja 1"});
        allOnTimeMissions.Add(new OnTimeMission(2, "A201", 40f) { Description = "Misja 2 tak trochê d³u¿sza"});

        allCollectMissions = new List<CollectMission>();
        allCollectMissions.Add(new CollectMission(5, 5, "CD") { Description = "Collect items mission"});

        allExevutableMissions = new List<ExecutableMission>();

        allTimeRestrictedMissions = new List<TimeRestrictedMission>();
    }

    public static void executeMissionForRoomNumber(string roomNumber) {
        Debug.Log(roomNumber);
        foreach(var mission in allOnTimeMissions) {
            if(mission.roomNumber == roomNumber) {
                mission.setFinalisedIfAllowed();
                Debug.Log(GetUnfinishedMissionsCount());
            }
        }
    }
    public static void CollectOneItem(string itemTag) {
        var mission = allCollectMissions.FirstOrDefault(m => m.CollectableTag == itemTag);
        if(mission != null) {
            mission.AddOneItem();
        }
        
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
}