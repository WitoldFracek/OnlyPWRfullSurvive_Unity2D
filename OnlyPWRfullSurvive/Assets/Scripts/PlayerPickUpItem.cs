using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpItem : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;
    [SerializeField] Rigidbody2D rigidBody;

    private GameObject collectable = null;
    
    void Start() {
        SetupKeys();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("HIT!");
        if(other.gameObject.tag == "Collectable") {
            collectable = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Collectable") {
            collectable = null;
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("HIT!");
        if(other.gameObject.tag == "Collectable") {
            collectable = other.gameObject;
        }
    }

    void SetupKeys() {
        actionMap["Interact"].performed += ctx => CollectItem();
    }

    private void CollectItem() {
        Debug.Log("E pressed");
        if(collectable != null) {
            Destroy(collectable);
            collectable = null;
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