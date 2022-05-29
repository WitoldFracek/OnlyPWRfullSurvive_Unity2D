using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    //Dialog
    [SerializeField] GameObject dialogBox;
    [SerializeField] Image npcImage;
    [SerializeField] Text dialogText;

    // Missions
    [SerializeField] GameObject missionBox;
    [SerializeField] Text timeDisplay;
    [SerializeField] Text ectsDisplay;
    [SerializeField] Text missionDisplay;
    [SerializeField] Text finalissedMissionDisplay;

    // HealthBars
    [SerializeField] EnergyBar player1Enegry;
    [SerializeField] EnergyBar player2Energy;

    // Laptop
    [SerializeField] GameObject laptop;
    [SerializeField] InputField consoleInput;
    [SerializeField] Text consoleResult;
    [SerializeField] List<GameObject> laptopIcons;

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


    public void MatchCommand()
    {
        string command = consoleInput.text;
        consoleResult.text = "";
        switch(command.ToLower())
        {
            case "debug":
                Debug.Log("debug");
                break;
            default:
                consoleResult.text = $"'{command}' is not recognized as an internal or external command, operable program or batch file.";
                break;
        }
        consoleInput.text = "";
    }

    public void SetDialogBoxActive(bool isActive)
    {
        dialogBox.SetActive(isActive);
    }

    public void SetLaptopActive(bool isActive)
    {
        laptop.SetActive(isActive);
    }



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
