using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDIconBehaviour : MonoBehaviour
{
    [SerializeField]
    public int executableMissionInx = -1;
    [SerializeField] AudioClip clickIconSound;

    private ExecutableMission mission;
    // Start is called before the first frame update
    void Start()
    {
        if(executableMissionInx == -1) {
            makeInvisibleVisible();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMissionInx(int missionInx) {
        this.executableMissionInx = missionInx;
        mission = MissionHandler.allExevutableMissions[missionInx];
        GetComponentInChildren<Text>().text = mission.FileDescription();
        makeVisible();
    }

    public void makeVisible() {
        this.GetComponent<Button>().gameObject.SetActive(true);
    }

    public void makeInvisibleVisible() {
        this.GetComponent<Button>().gameObject.SetActive(false);
        executableMissionInx = -1;
    }

    public void onClick() {
        MissionHandler.ExecuteExecutableMission(executableMissionInx);
        AudioSource.PlayClipAtPoint(clickIconSound, transform.root.position);
        if (mission.WasFinalised)
        {
            makeInvisibleVisible();
        }
    }
}
