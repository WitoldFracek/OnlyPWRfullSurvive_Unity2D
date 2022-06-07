using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenHandler : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text buttonText;
    void Start()
    {
        if(MissionHandler.GetCurrentECTSCount() >= Constants.minToPassEcts) {
            title.text = $"You survived!\nYou have {MissionHandler.GetCurrentECTSCount()}/{Constants.maxEcts} ECTS";
        }
        else {
            title.text = "You are not PWRfull enough!\nTry again.";
        }
    }

    public void backToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
