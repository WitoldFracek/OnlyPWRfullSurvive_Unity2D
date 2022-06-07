using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text buttonText;
    private Color orange = new Color(1, 0.65f, 0);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = orange;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = Color.white;
    }

    public void startLevel1() {
        BetweenScenesParams.currentLevel = 1;
        BetweenScenesParams.currentEnergyLevel = Constants.maxEnergyLevel;
        startGame();
    }

    public void startLevel2() {
        BetweenScenesParams.currentLevel = 2;
        BetweenScenesParams.currentEnergyLevel = Constants.maxEnergyLevel/2;
        startGame();
    }

    public void startLevel3() {
        BetweenScenesParams.currentLevel = 3;
        BetweenScenesParams.currentEnergyLevel = Constants.maxEnergyLevel/3;
        startGame();
    }

    private void startGame() {
        SceneManager.LoadScene("BetweenBuildings");
    }
}
