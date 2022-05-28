using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
}
