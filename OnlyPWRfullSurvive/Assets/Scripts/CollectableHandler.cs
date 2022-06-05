using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableHandler : MonoBehaviour, InteractAction
{
    [SerializeField] public string collectableTag;
    [SerializeField] GameObject textHint;

    private void Start()
    {
        textHint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
        MissionHandler.PassCollectable(collectableTag);
        Destroy(gameObject);
    }
}
