using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopPopup : InteractableHandler
{
    override public void Interact()
    {
        hud.SetLaptopActive(true);
    }
}
