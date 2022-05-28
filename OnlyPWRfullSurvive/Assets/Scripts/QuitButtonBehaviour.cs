using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuitButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image buttonImage;
    private Color crimson = new Color(0.86f, 0.078f, 0.235f);
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = crimson;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = Color.red;
    }
}
