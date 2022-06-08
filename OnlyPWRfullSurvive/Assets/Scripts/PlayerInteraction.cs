using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;
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
    }

    public void Interact() {
        if(interactable != null) {
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