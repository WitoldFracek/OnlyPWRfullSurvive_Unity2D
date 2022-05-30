using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoDiffFloorBehavior : MonoBehaviour, InteractAction
{
    [SerializeField]
    private string nextSceneName;

    public void goToNextScene() {
        SceneManager.LoadScene(nextSceneName);
    }

    public void Interact() {
        goToNextScene();
    }
}
