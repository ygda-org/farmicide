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

    // GAMEOBJECT REFERENCES
    public GameObject currentGun;
    public GameObject currentPlant;

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

    public void Interact() {
        // find if there are any objects close to the player that they can interact with and then return that object
        // current interactables are the shop and planting
    }

    public void Shoot() {
        // example sudo code for the shotgun:
        // create 5 bullet prefabs that each have a random angle relative to the player
        // jerk the player in the opposite direction that they fire
        // give the player endlag
        // in reality we would have different classes for guns and they would each have different properties under one parent class
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
