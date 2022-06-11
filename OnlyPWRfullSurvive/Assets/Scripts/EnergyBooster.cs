using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBooster : MonoBehaviour, InteractAction//InteractableHandler
{
    [SerializeField]
    private float maxEnergyPercent = 0.1f;

    [SerializeField] AudioClip energyBoosterSound;
    public void Interact() {
        BetweenScenesParams.currentEnergyLevel = Mathf.Min((int) (Constants.maxEnergyLevel * maxEnergyPercent) + BetweenScenesParams.currentEnergyLevel, Constants.maxEnergyLevel);
        AudioSource.PlayClipAtPoint(energyBoosterSound, transform.position);
        Destroy(gameObject);
    }


    public bool IsAnimated()
    {
        return true;
    }
}
