using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBooster : MonoBehaviour, InteractAction//InteractableHandler
{
    [SerializeField]
    private float maxEnergyPercent = 0.1f;

    [SerializeField] GameObject textHint;

    [SerializeField] AudioClip energyBoosterSound;
    public void Interact() {
        BetweenScenesParams.currentEnergyLevel = Mathf.Min((int) (Constants.maxEnergyLevel * maxEnergyPercent) + BetweenScenesParams.currentEnergyLevel, Constants.maxEnergyLevel);
        AudioSource.PlayClipAtPoint(energyBoosterSound, transform.position);
        Destroy(gameObject);
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


    public bool IsAnimated()
    {
        return true;
    }
}
