using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossFightPlayerMovement : MonoBehaviour
{
    public float movmentSpeed = 7f;
    public float jumpPower = 10f;
    [Range(0, 0.5f)] [SerializeField] public float movementSmoothing = 0.01f;
    [SerializeField] GameObject otherPlayer;

    [SerializeField] public InputActionMap actionMap;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Transform groundCheck;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float verticalMovment = 0f;
    private float horizontalMovement = 0f;

    private float moveLeft = 0f;
    private float moveRight = 0f;
    private float groundedRadius = 0.2f;
    private bool canJump = true;

    private static bool isOtherPlayerInGame;
    void Start()
    {
        SetupMovementKeys();
    }

    private void FixedUpdate()
    {
        moveLeft = movmentSpeed * actionMap["Left"].ReadValue<float>();
        moveRight = movmentSpeed * actionMap["Right"].ReadValue<float>();

        Vector2 targetVelocity = new Vector2(moveRight - moveLeft, 0) + rigidBody.velocity;
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void Jump()
    {
        rigidBody.AddForce(rigidBody.velocity + new Vector2(0, jumpPower));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
    }

    private void SetupMovementKeys()
    {
        actionMap["Jump"].performed += ctx => Jump();
    }
}
