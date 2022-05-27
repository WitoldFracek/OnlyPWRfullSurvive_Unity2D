using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

    [SerializeField] Slider slider;
    public int maxEnergy = 0;

    private void Start() {
        slider.maxValue = maxEnergy;
        slider.minValue = 0;
    }

    public void SetEnergyLevel(int energy) {
        slider.value = Mathf.Min(energy, slider.maxValue);
    }

}
