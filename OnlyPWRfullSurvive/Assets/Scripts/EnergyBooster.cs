using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBooster : InteractableHandler
{
    [SerializeField]
    private float maxEnergyPercent = 0.1f;
    override public void Interact() {
        BetweenScenesParams.currentEnergyLevel = Mathf.Min((int) (Constants.maxEnergyLevel * maxEnergyPercent) + BetweenScenesParams.currentEnergyLevel, Constants.maxEnergyLevel);
        Destroy(gameObject);
    }
}