using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyBar : MonoBehaviour {

    [SerializeField] Slider slider;
    private void Start() {
        slider.maxValue = Constants.maxEnergyLevel;
        slider.minValue = 0;
    }

    public void SetEnergyLevel(int energy) {
        slider.value = Mathf.Min(energy, slider.maxValue);
    }

    public void Update() {
        SetEnergyLevel(BetweenScenesParams.currentEnergyLevel);
        if(slider.value < Constants.maxEnergyLevel / 4) {
            slider.GetComponentInChildren<Image>().color = Color.red;
        }
        else {
            slider.GetComponentInChildren<Image>().color = new Color(0, 148, 255);
        }
        if(BetweenScenesParams.currentEnergyLevel == 0) {
            SceneManager.LoadScene("EndingScreen");
        }
    }
}
