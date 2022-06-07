using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSetupScript : MonoBehaviour
{
    [SerializeField] public HUDController hud;
    void Start()
    {
        if(!MissionHandler.areMissionsSetup()) {
            if(BetweenScenesParams.currentLevel == 1) {
                MissionHandler.setLevel1Missions();
            }
            else if(BetweenScenesParams.currentLevel == 2) {
                MissionHandler.setLevel2Missions();
            }
            else if(BetweenScenesParams.currentLevel == 3) {
                MissionHandler.setLevel3Missions();
            }
        }
        
        // hud.SetMissions(MissionHandler.GetAllUnfinishedMissions());
    }
}
