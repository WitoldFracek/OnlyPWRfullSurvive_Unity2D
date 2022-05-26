using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CollectableHandler : MonoBehaviour
{
    [SerializeField] InputActionMap actionMap;
    // private bool playerInRange = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerPickUpItem>().SetCollectable(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerPickUpItem>().SetCollectable(null);
        }
    }

    // void SetupKeys() {
    //     actionMap["Interact"].performed += ctx => CollectItem();
    // }

    // private void CollectItem() {
    //     Debug.Log("E pressed");
    //     if(playerInRange) {
    //         Destroy(this.gameObject);
    //     }
    // }

    // private void OnEnable() {
    //     actionMap.Enable();
    // }

    // private void OnDisable() {
    //     actionMap.Disable();
    // }
}
