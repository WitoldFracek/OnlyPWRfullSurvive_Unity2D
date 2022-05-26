using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoDiffFloorBehavior : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    public void goToNextScene() {
        SceneManager.LoadScene(nextSceneName);
    }
}
