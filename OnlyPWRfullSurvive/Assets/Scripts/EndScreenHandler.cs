using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenHandler : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text buttonText;
    [SerializeField] Image image;
    [SerializeField] Sprite successSprite;
    [SerializeField] Sprite defeatSprite;
    void Start()
    {
        if(MissionHandler.GetCurrentECTSCount() >= Constants.minToPassEcts) {
            title.text = $"You survived!\nYou have {MissionHandler.GetCurrentECTSCount()}/{Constants.maxEcts} ECTS";
            image.sprite = successSprite;
        }
        else {
            title.text = $"You are not PWRfull enough!\nYou need at least {Constants.minToPassEcts}/{Constants.maxEcts} ECTS to pass.\nYou have {MissionHandler.GetCurrentECTSCount()} ECTS";
            image.sprite = defeatSprite;
        }
    }

    public void backToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
