using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private Transform player;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
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
