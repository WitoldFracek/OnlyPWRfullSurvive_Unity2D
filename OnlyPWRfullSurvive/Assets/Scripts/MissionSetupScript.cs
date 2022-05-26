using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSetupScript : MonoBehaviour
{
    [SerializeField]
    public int level;
    void Start()
    {
        if(level == 1) {
            MissionHandler.setLevel1Missions();
        }
    }

}
