using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoDiffFloorBehavior : InteractableHandler
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    public string teleportPointId;

    public void goToNextScene() {
        BetweenScenesParams.teleportPointId = teleportPointId;
        SceneManager.LoadScene(nextSceneName);
    }

    override public void Interact() {
        goToNextScene();
    }
}
