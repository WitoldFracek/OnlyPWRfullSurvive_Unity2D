using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingNPCScript : MonoBehaviour, InteractAction
{

    [SerializeField] HUDController hud;
    [SerializeField] GameObject interactionText;
    [SerializeField] List<string> messages;
    [SerializeField] Sprite npcSprite;
    public void Interact()
    {
        hud.PassDialogParameters(messages, npcSprite);
        hud.StartDialog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interactionText.SetActive(false);
        }
    }

    public bool IsAnimated()
    {
        return false;
    }
}
