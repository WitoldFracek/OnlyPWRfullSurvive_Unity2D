using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;
    private GoDiffFloorBehavior goDiffFloor = null;

    private void OnTriggerEnter2D(Collider2D other) {
        var diff = other.gameObject.GetComponent<GoDiffFloorBehavior>();
        if(diff != null) {
            goDiffFloor = diff;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        var diff = other.gameObject.GetComponent<GoDiffFloorBehavior>();
        if(diff != null) {
            goDiffFloor = null;
        }
    }

    private void Start() {
        actionMap["Interact"].performed += ctx => Interact();
    }

    private void Interact() {
        if(goDiffFloor != null) {
            goDiffFloor.goToNextScene();
        }
    }
    
    private void OnEnable() {
        actionMap.Enable();
    }

    private void OnDisable() {
        actionMap.Disable();
    }

}