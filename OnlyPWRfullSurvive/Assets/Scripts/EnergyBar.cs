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

    public void ChangeEnergyLevelBy(int diff) {
        slider.value = Mathf.Min(slider.value + diff, slider.maxValue);
        if(slider.value < Constants.maxEnergyLevel / 4) {
            slider.GetComponentInChildren<Image>().color = Color.red;
        }
        else {
            slider.GetComponentInChildren<Image>().color = Color.blue;
        }
    }

    public void SetMax() {
        slider.value = Constants.maxEnergyLevel;
        slider.GetComponentInChildren<Image>().color = Color.blue;
    }

    public void Update() {
        SetEnergyLevel(BetweenScenesParams.currentEnergyLevel);
        if(slider.value < Constants.maxEnergyLevel / 4) {
            slider.GetComponentInChildren<Image>().color = Color.red;
        }
        if(BetweenScenesParams.currentEnergyLevel == 0) {
            SceneManager.LoadScene("EndingScreen");
        }
    }
}
