using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    private int playerNumber;

    // MOVEMENT GLOBAL VARIABLES
    public float moveSpeed = 3;
    public float aimSpeed = 150; // only for keyboard

    private Vector2 velocity;
    public float aimDirection; // in degrees counterClockWise from the +x-axis
    public enum Directions { right, left }
    

    // whenever this value is changed, it automatically changes the player's direction in game
    public Directions currentDirection {
        get { 
            if (transform.localScale.x < 0) return Directions.left;
            return Directions.right;
        }
        set {
            if (currentDirection != value) 
                transform.localScale = new(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
        }
    }




    // GAMEOBJECT/SCRIPT REFERENCES
    public Rigidbody2D player;
    public SpriteRenderer spriteRenderer;
    public PlantGrid plantGrid;
    public GameObject aimReticle;

    public GameObject currentGun;
    public GameObject currentPlant;
    

    // INPUT GLOBAL VARIABLES
    private PlayerInput playerInput;

    [SerializeField]
    private Vector2 movementInput = new(0f, 0f);

    [SerializeField]
    private Vector2 aimInput = new(0f, 0f);

    [SerializeField]
    private bool isPressedInteract, isPressedShoot, isPressedAimClockWise, isPressedAimCounterClockWise;



    // private void OnEnable() { playerInput.enabled = true; }
    // private void OnDisable() { playerInput.enabled = false; }
    private void OnButtonPressed(ref bool button) { button = true; }
    private void OnButtonReleased(ref bool button) { button = false; }

    private void InitializeControls(PlayerInput playerInput_) {
        playerInput = playerInput_;

        InputAction Move = playerInput.actions["Move"];
        Move.performed += context => {
            movementInput = context.ReadValue<Vector2>();
            if (movementInput.x > 0) currentDirection = Directions.right;
            if (movementInput.x < 0) currentDirection = Directions.left;
        };
        Move.canceled += context => movementInput = new(0, 0);

        InputAction Interact = playerInput.actions["Interact"];
        Interact.started += context => {
            OnButtonPressed(ref isPressedInteract);
            this.Interact();
        };
        Interact.canceled += context => OnButtonReleased(ref isPressedInteract);

        InputAction Shoot = playerInput.actions["Shoot"];
        Shoot.started += context => {
            OnButtonPressed(ref isPressedShoot);
            this.Shoot();
        };
        Shoot.canceled += context => OnButtonReleased(ref isPressedShoot);

        InputAction Aim = playerInput.actions["Aim"];
        Aim.performed += context => {
            aimInput = context.ReadValue<Vector2>();
            aimDirection = (float)Mathf.Atan2(aimInput.y, aimInput.x) * Mathf.Rad2Deg;
        };
        Aim.canceled += context => aimInput = new(0, 0);

        InputAction AimClockWise = playerInput.actions["AimClockWise"];
        AimClockWise.started += context => OnButtonPressed(ref isPressedAimClockWise);
        AimClockWise.canceled += context => OnButtonReleased(ref isPressedAimClockWise);

        InputAction AimCounterClockWise = playerInput.actions["AimCounterClockWise"];
        AimCounterClockWise.started += context => OnButtonPressed(ref isPressedAimCounterClockWise);
        AimCounterClockWise.canceled += context => OnButtonReleased(ref isPressedAimCounterClockWise);

    }
    public void OnPlayerJoined(PlayerInput playerInput_, int playerNumber_) {

        playerNumber = playerNumber_;

        // make player 2 face the correct way
        if (playerNumber == 1) {
            aimDirection = 180;
            currentDirection = Directions.left;
        }
        
        InitializeControls(playerInput_);
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

    void Input() {
        velocity = new Vector2(movementInput.x, movementInput.y);
    }

    void Move() {
        player.velocity = new(velocity.x * moveSpeed * Time.deltaTime, velocity.y * moveSpeed * Time.deltaTime);

        if (isPressedAimClockWise)
            aimDirection = (aimDirection - aimSpeed * Time.deltaTime) % 360;
        
        if (isPressedAimCounterClockWise)
            aimDirection = (aimDirection + aimSpeed * Time.fixedDeltaTime) % 360;

        aimReticle.transform.eulerAngles = new(0, 0, aimDirection);
    }


    void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        Move();
    }

}
