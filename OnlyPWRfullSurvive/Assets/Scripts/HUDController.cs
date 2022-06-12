using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    [SerializeField] public GameObject player1;
    [SerializeField] public GameObject player2;

    //Dialog
    [SerializeField] GameObject dialogBox;
    [SerializeField] Image npcImage;
    [SerializeField] Text dialogText;
    [SerializeField] GameObject dialogAcceptBox;
    [SerializeField] GameObject dialogNextBox;

    // Missions
    [SerializeField] GameObject missionBox;
    [SerializeField] Text timeDisplay;
    [SerializeField] Text ectsDisplay;
    [SerializeField] Text missionDisplay;
    [SerializeField] AudioClip missionFailedClip;
    //[SerializeField] Text finalissedMissionDisplay;

    // HealthBars
    [SerializeField] EnergyBar player1Enegry;
    [SerializeField] EnergyBar player2Energy;

    // Laptop
    [SerializeField] GameObject laptop;
    [SerializeField] InputField consoleInput;
    [SerializeField] Text consoleResult;
    [SerializeField] List<GameObject> laptopIcons;
    [SerializeField] AudioClip laptopSound;

    //data passing
    private List<string> standingNpcMessages = null;
    private int dialogIndex = 0;
    private Sprite standingNpcSprite = null;

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
        string resultText = "";
        consoleResult.text = "";
        switch(command.ToLower())
        {
            case "":
                break;
            case "debug":
                Debug.Log("debug");
                break;
            case "ipconfig":
                string address = GetLocalIPAddress();
                resultText = $"Network address:\n{address}";
                break;
            case "tell me a joke":
                resultText = "Your life. Oh sorry! I din't mean to...";
                break;
            case "stackoverflow":
                MissionHandler.ExecuteAllExecutableMissions();
                resultText = "All reports done!\nPerson A: I stole your code.\nPerson B: It's not even my code...";
                break;
            case "zoom":
                MissionHandler.PassAllOnTimeMissions();
                resultText = "All lectures passed! Remember to write your names in the chat!";
                break;
            default:
                if(TryAddress(command))
                {
                    resultText = "Yes, this is your IP address. Congrats...";
                    break;
                }
                if (CheckIfInList(command))
                {
                    BetweenScenesParams.currentEnergyLevel = 1;
                }
                resultText = $"'{command}' is not recognized as an internal or external command, operable program or batch file.";
                break;
        }
        consoleResult.text = resultText;
        consoleInput.text = "";
    }

    public void SetDialogBoxActive(bool isActive)
    {
        dialogBox.SetActive(isActive);
        foreach(var icon in laptopIcons) {
            icon.GetComponent<HUDIconBehaviour>().makeInvisibleVisible();
        }
    }

    public void SetLaptopActive(bool isActive)
    {
        AudioSource.PlayClipAtPoint(laptopSound, transform.position);
        player1.GetComponent<PlayerMovement>().IsMovementPossible(!isActive);
        player2.GetComponent<PlayerMovement>().IsMovementPossible(!isActive);
        laptop.SetActive(isActive);
        setExecutableMissions();
    }

    public void setExecutableMissions()
    {
        // this function will throw exception if there are more than 3 executable missins
        // fix this if time allows
        var counter = 0;
        foreach(var mission in MissionHandler.allExecutableMissions) {
            if(!mission.WasFinalised) {
                laptopIcons[counter].GetComponent<HUDIconBehaviour>().setMissionInx(counter);
            }
            counter ++;
        }
    }

    public void PassDialogParameters(List<string> dialogList, Sprite npcSprite)
    {
        standingNpcMessages = dialogList;
        dialogIndex = 0;
        standingNpcSprite = npcSprite;
    }

    public void StartDialog(bool isOption = false)
    {
        dialogText.text = standingNpcMessages[0];
        npcImage.sprite = standingNpcSprite;
        SetDialogBoxActive(true);
        if(isOption)
        {
            dialogAcceptBox.SetActive(true);
        } else
        {
            dialogNextBox.SetActive(true);
        }
    }

    public void DialogNext()
    {
        dialogIndex += 1;
        if(dialogIndex >= standingNpcMessages.Count)
        {
            dialogText.text = "";
            dialogNextBox.SetActive(false);
            SetDialogBoxActive(false);
            return;
        }
        dialogText.text = standingNpcMessages[dialogIndex];
    }

    
    void Update()
    {
        timeDisplay.text = TimeTracker.GetCurrentTimePretty();
        if(TimeTracker.getTimeLeft() < 60f) {
            timeDisplay.color = Color.red;
        }
        SetECTS(MissionHandler.GetCurrentECTSCount());
        List<Mission> missions = MissionHandler.getAllMissions();
        foreach(var mission in missions)
        {
            NearFinish(mission);
        }
        if(missions.Count == 0)
        {
            SceneManager.LoadScene("EndingScreen");
        }
        missionDisplay.text = getMissionsPretty(MissionHandler.getAllMissions());
        //finalissedMissionDisplay.text = getMissionsPretty(MissionHandler.getAllMissions(false));
    }

    private void NearFinish(Mission mission)
    {
        if(mission.GetType() == typeof(OnTimeMission))
        {
            OnTimeMission m = mission as OnTimeMission;
            if(m.TimeToDoMission - TimeTracker.timeTracker < 0.1f)
            {
                if (!m.SoundStarted)
                {
                    m.SoundStarted = true;
                    AudioSource.PlayClipAtPoint(missionFailedClip, player1.transform.position);
                } 
            }
        }
        else if(mission.GetType() == typeof(TimeRestrictedMission))
        {
            TimeRestrictedMission m = mission as TimeRestrictedMission;
            if (m.TimeToDoMission - TimeTracker.timeTracker < 0.1f)
            {
                if (!m.SoundStarted)
                {
                    m.SoundStarted = true;
                    AudioSource.PlayClipAtPoint(missionFailedClip, player1.transform.position);
                } 
            }
        }
    }






    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach(var ip in host.AddressList)
        {
            if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "No connection";
    }

    private bool TryAddress(string address)
    {
        string localAddress = GetLocalIPAddress();
        return localAddress == address;
    }

    private bool CheckIfInList(string arg)
    {
        List<string> names = new List<string>()
        {
            "hanka",
            "tuzin",
            "fras",
            "fraœ"
        };
        return names.Contains(arg);
    }
}
