using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject missionBox;
    [SerializeField] Image npcImage;
    [SerializeField] Text dialogText;
    [SerializeField] Text timeDisplay;
    [SerializeField] Text ectsDisplay;
    [SerializeField] Text missionDisplay;
    [SerializeField] Text finalissedMissionDisplay;

    // public void SetTime(float time)
    // {
    //     int hour = (int)time / 60;
    //     int minute = (int)(time - hour * 60);
    //     string zero = "";
    //     if(minute < 10)
    //     {
    //         zero = "0";
    //     }
    //     timeDisplay.text = $"{hour}:{zero}{minute}";
    // }

    public void SetECTS(int ects)
    {
        ectsDisplay.text = $"ECTS: {ects}/30";
    }

    public static string getMissionsPretty(List<Mission> missions) {
        string missionText = "";
        foreach(var mission in missions)
        {
            missionText += mission.ToString();
            missionText += '\n';
        }
        return missionText;
    }

    // public void SetMissions(List<Mission> missions)
    // {
    //     string missionText = "";
    //     foreach(var mission in missions)
    //     {
    //         missionText += mission.ToString();
    //         missionText += '\n';
    //     }
    //     missionDisplay.text = missionText;
    // }

    


    void Start()
    {

    }

    
    void Update()
    {
        timeDisplay.text = TimeTracker.GetCurrentTimePretty();
        SetECTS(MissionHandler.GetCurrentECTSCount());
        missionDisplay.text = getMissionsPretty(MissionHandler.getAllMissions());
        finalissedMissionDisplay.text = getMissionsPretty(MissionHandler.getAllMissions(false));
    }
}
