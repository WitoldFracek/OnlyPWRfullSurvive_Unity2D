using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface InteractAction {
    void Interact();
    bool IsAnimated();
}

public class InteractableHandler: MonoBehaviour, InteractAction
{
    protected HUDController hud;
    [SerializeField] protected GameObject textHint;

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDController>();
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

    public virtual void Interact(){
        Debug.Log("Method E not implemented");
    }

    public virtual bool IsAnimated()
    {
        return false;
    }
}
