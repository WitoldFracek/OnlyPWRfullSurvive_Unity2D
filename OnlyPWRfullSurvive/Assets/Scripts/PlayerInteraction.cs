using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] public InputActionMap actionMap;
    private Animator animator;
    private InteractAction interactable;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable") {
            interactable = other.gameObject.GetComponent<InteractAction>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Interactable") {
            interactable = null;
        }
    }

    private void Start() {
        actionMap["Interact"].performed += ctx => Interact();
        animator = gameObject.GetComponent<Animator>();
    }

    public void Interact() {
        if(interactable != null) {
            if (interactable.IsAnimated())
            {
                animator.SetTrigger("PickupTrigger");
            }
            interactable.Interact();
        }
    }
    
    private void OnEnable() {
        actionMap.Enable();
    }

    private void OnDisable() {
        actionMap.Disable();
    }

}