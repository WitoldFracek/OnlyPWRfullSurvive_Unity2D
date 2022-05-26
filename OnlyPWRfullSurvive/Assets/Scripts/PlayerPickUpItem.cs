using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpItem : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;

    private GameObject collectable = null;

    private int tempCount = 0;
    
    void Start() {
        SetupKeys();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Collectable") {
            collectable = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Collectable") {
            collectable = null;
        }
    }

    void SetupKeys() {
        actionMap["Interact"].performed += ctx => CollectItem();
    }

    private void CollectItem() {
        if(collectable != null) {
            Destroy(collectable);
            collectable = null;
            tempCount += 1;
            Debug.Log(tempCount.ToString());
        }
    }

    public void SetCollectable(GameObject col) {
        collectable = col;
    }

    private void OnEnable() {
        actionMap.Enable();
    }

    private void OnDisable() {
        actionMap.Disable();
    }


}