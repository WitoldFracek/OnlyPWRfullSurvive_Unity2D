using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    void Start()
    {
        var allTeleportToPotential = GameObject.FindObjectsOfType<GoDiffFloorBehavior>();
        foreach (var teleportToPotential in allTeleportToPotential) {
            if(teleportToPotential.teleportPointId == BetweenScenesParams.teleportPointId) {
                player.transform.position = teleportToPotential.transform.position;
            }
        }
    }
}
