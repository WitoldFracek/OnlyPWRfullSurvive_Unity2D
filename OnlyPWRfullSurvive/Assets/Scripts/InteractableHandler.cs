using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

class InteractableHandler: MonoBehaviour
{
    [SerializeField] HUDController hud;
    [SerializeField] GameObject textHint;
    [SerializeField] string mode;

    private void Start()
    {
        textHint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textHint.SetActive(false);
        }
    }

    public void Interact()
    {
        if(mode == "laptop")
        {
            ShowLaptop();
        }
    }

    private void ShowLaptop()
    {
        hud.SetLaptopActive(true);
    }
}
