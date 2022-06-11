using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpItem : MonoBehaviour {

    [SerializeField] InputActionMap actionMap;

    private GameObject collectable = null;
    private Animator animator;

    private int tempCount = 0;
    
    void Start() {
        SetupKeys();
        animator = gameObject.GetComponent<Animator>();
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

    public void CollectItem() {
        if(collectable != null) {
            animator.SetTrigger("PickupTrigger");
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