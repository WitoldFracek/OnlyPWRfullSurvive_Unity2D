using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;
    private GoDiffFloorBehavior goDiffFloor = null;
    private InteractableHandler interactable;

    private void OnTriggerEnter2D(Collider2D other) {
        var diff = other.gameObject.GetComponent<GoDiffFloorBehavior>();
        if(diff != null) {
            goDiffFloor = diff;
            return;
        }
        if(other.gameObject.tag == "Interactable")
        {
            interactable = other.gameObject.GetComponent<InteractableHandler>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        var diff = other.gameObject.GetComponent<GoDiffFloorBehavior>();
        if(diff != null) {
            goDiffFloor = null;
            return;
        }
        if (other.gameObject.tag == "Interactable")
        {
            interactable = null;
        }
    }

    private void Start() {
        actionMap["Interact"].performed += ctx => Interact();
    }

    private void Interact() {
        if(goDiffFloor != null) {
            goDiffFloor.goToNextScene();
        }
        if(interactable != null)
        {
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