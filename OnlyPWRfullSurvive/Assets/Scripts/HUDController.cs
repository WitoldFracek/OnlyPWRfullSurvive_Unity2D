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

    public void SetTime(float time)
    {
        int hour = (int)time / 60;
        int minute = (int)(time - hour * 60);
        string zero = "";
        if(minute < 10)
        {
            zero = "0";
        }
        timeDisplay.text = $"{hour}:{zero}{minute}";
    }

    public void SetECTS(int ects)
    {
        ectsDisplay.text = $"ECTS: {ects}";
    }

    public void SetMissions(List<Mission> missions)
    {
        string missionText = "";
        foreach(var mission in missions)
        {
            missionText += mission.Description;
            missionText += '\n';
        }
        missionDisplay.text = missionText;
    }


    void Start()
    {

    }

    
    void Update()
    {
        SetTime(TimeTracker.timeTracker);
    }
}
