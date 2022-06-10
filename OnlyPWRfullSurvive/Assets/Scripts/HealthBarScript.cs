using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    private void Start()
    {
        slider.maxValue = Constants.maxHealthLevel;
        slider.minValue = 0;
        slider.value = Constants.maxHealthLevel;
    }

    public void SetEnergyLevel(int energy)
    {
        slider.value = Mathf.Min(energy, slider.maxValue);
    }

    public void Update()
    {
        if (slider.value == 0)
        {
            //SceneManager.LoadScene("EndingScreen");
        }
    }
}
