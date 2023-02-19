// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    int playerNumber;
    // MOVEMENT GLOBAL VARIABLES
    public float moveSpeed = 3;
    public Rigidbody2D player;
    private Vector2 velocity;

    // INPUT GLOBAL VARIABLES
    private PlayerInput playerInput;

    [SerializeField]
    private Vector2 movementInput = new(0f, 0f);

    [SerializeField]
    private Vector2 aimInput = new(0f, 0f);

    [SerializeField]
    private bool isPressedInteract, isPressedShoot;

    

    // private void OnEnable() { playerInput.enabled = true; }
    // private void OnDisable() { playerInput.enabled = false; }
    private void OnButtonPressed(ref bool button) { button = true; }
    private void OnButtonReleased(ref bool button) { button = false; }
    private void AimClockWise() {}
    private void AimCounterClockWise() {}

    public void OnPlayerJoined(PlayerInput playerInput_, int playerNumber_) {
        playerInput = playerInput_;
        playerNumber = playerNumber_;


        InputAction Move = playerInput.actions["Move"];
        Move.performed += context => movementInput = context.ReadValue<Vector2>();
        Move.canceled += context => movementInput = new(0, 0);

        InputAction Aim = playerInput.actions["Aim"];
        Aim.performed += context => aimInput = context.ReadValue<Vector2>();
        Aim.canceled += context => aimInput = new(0, 0);

        InputAction Interact = playerInput.actions["Interact"];
        Interact.started += context => OnButtonPressed(ref isPressedInteract);
        Interact.canceled += context => OnButtonReleased(ref isPressedInteract);

        InputAction Shoot = playerInput.actions["Shoot"];
        Shoot.started += context => OnButtonPressed(ref isPressedShoot);
        Shoot.canceled += context => OnButtonReleased(ref isPressedShoot);
    }

    void Awake() {
    }
    void Update()
    {
        input();
    }

    private void FixedUpdate()
    {
        move();
    }

    void input() {
        // float moveX = Input.GetAxisRaw("Horizontal");
        // float moveY = Input.GetAxisRaw("Vertical");
        float moveX = movementInput.x;
        float moveY = movementInput.y;
        velocity = new Vector2(moveX, moveY);
    }

    void move() {
        player.velocity = new Vector2(velocity.x * moveSpeed * Time.deltaTime, velocity.y * moveSpeed * Time.deltaTime);
    }
}
