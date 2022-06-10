using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableHandler : MonoBehaviour, InteractAction
{
    [SerializeField] public string collectableTag;
    [SerializeField] public string id;
    [SerializeField] public int level;
    [SerializeField] GameObject textHint;
    [SerializeField] AudioClip collectSound;

    private void Start()
    {
        textHint.SetActive(false);
        if(level == 0) return;
        if(level != BetweenScenesParams.currentLevel) {
            Destroy(gameObject);
            return;
        }
        foreach(var mission in MissionHandler.allCollectMissions) {
            if(mission.collectedIds.Contains(id)) {
                Destroy(gameObject);
            }
        }
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
        MissionHandler.PassCollectable(this);
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        Destroy(gameObject);
    }
}
