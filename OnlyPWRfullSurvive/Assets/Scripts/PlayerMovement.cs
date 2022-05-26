using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Params
    public float movmentSpeed = 4000f;
    [Range(0, 0.5f)][SerializeField] public float movementSmoothing = 0.01f;

    [SerializeField] InputActionMap actionMap;
    [SerializeField] Rigidbody2D rigidBody;

    private Vector3 velocity = Vector3.zero;
    private float verticalMovment = 0f;
    private float horizontalMovement = 0f;

    private float moveLeft = 0f;
    private float moveRight = 0f;
    private float moveDown = 0f;
    private float moveUp = 0f;

    private bool collectableInRange = false;

    
    void Start()
    {
        SetupMovementKeys();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate() {
        moveUp = movmentSpeed * actionMap["Up"].ReadValue<float>();
        moveDown = movmentSpeed * actionMap["Down"].ReadValue<float>();
        moveLeft = movmentSpeed * actionMap["Left"].ReadValue<float>();
        moveRight = movmentSpeed * actionMap["Right"].ReadValue<float>();
        Vector2 targetVelocity = new Vector2(moveRight - moveLeft, moveUp - moveDown);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void OnEnable() {
        actionMap.Enable();
    }

    private void OnDisable() {
        actionMap.Disable();
    }

    private void SetupMovementKeys() {
        // actionMap["Up"].started += cts => MovePlayer(0, 1);
        // actionMap["Up"].canceled += cts => StopPlayer();
        // actionMap["Down"].started += cts => MovePlayer(0, -1);
        // actionMap["Down"].canceled += cts => StopPlayer();
        // actionMap["Left"].started += cts => MovePlayer(-1, 0);
        // actionMap["Left"].canceled += cts => StopPlayer();
        // actionMap["Right"].started += cts => MovePlayer(1, 0);
        // actionMap["Right"].canceled += cts => StopPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Collectable") {

        }
    }

    

    void MovePlayer(int xMultiplier, int yMultiplier) {
        // Debug.Log(movmentSpeed * Time.deltaTime * xMultiplier);
        // Debug.Log(movmentSpeed * Time.deltaTime * yMultiplier);
        verticalMovment = verticalMovment + movmentSpeed * yMultiplier;
        horizontalMovement = horizontalMovement + movmentSpeed * xMultiplier;
        //var  = new targetVelocityVector2(movmentSpeed * Time.deltaTime * xMultiplier, movmentSpeed * Time.deltaTime * yMultiplier);
        //rigidBody.velocity = rigidBody.velocity + movmentSpeed * Time.deltaTime * new Vector2(xMultiplier, yMultiplier);
        //rigidBody.AddForce(new Vector2(movmentSpeed * Time.deltaTime * xMultiplier, movmentSpeed * Time.deltaTime * yMultiplier));
        //rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    void StopPlayer() {
        verticalMovment = 0;
        horizontalMovement = 0;
    }

}
