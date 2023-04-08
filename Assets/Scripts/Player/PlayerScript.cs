using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    private int playerNumber;


    public double maxHealth;
    public double currentHealth;
    public Slider healthSlider;

    public double getHealth() {
        return currentHealth;
    }
    public void setHealth(double newHealth) {
        currentHealth = newHealth;
        healthSlider.value = (float)newHealth;
    }


    public TextMeshProUGUI moneyText;
    public int startingMoney;
    private int money;
    public void setMoney(int money_) {
        money = money_;
        if (playerNumber == 1) moneyText.text = "P1: $" + money;
        else if (playerNumber == 2) moneyText.text = "P2: $" + money;
    }
    public int getMoney() {
        return money;
    }



    // MOVEMENT GLOBAL VARIABLES
    public float moveSpeed = 3;
    public float aimSpeed = 150; // only for keyboard
    public bool movementIsDisabled;

    private Vector2 velocity;
    public float aimDirection; // in degrees counterClockWise from the +x-axis

    public float zAxisScalingMultipler; // helps to give the illusion that the player is moving into the screen when they move up
    private Vector3 defaultScale;


    public enum Directions { right, left }
    

    // whenever this value is changed, it automatically changes the player's direction in game
    public Directions CurrentDirection {
        get { 
            if (transform.localScale.x < 0) return Directions.left;
            return Directions.right;
        }
        set {
            if (CurrentDirection != value) {
                transform.localScale = new(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                // make sure that the aim reticle doesn't do weird things
                Vector3 UIContainerScale = UIContainer.transform.localScale;
                UIContainer.transform.localScale = new(-UIContainerScale.x, UIContainerScale.y, UIContainerScale.z);
            }
            
        }
    }




    // GAMEOBJECT/SCRIPT REFERENCES
    public Rigidbody2D player;
    public GameObject enemyPlayer;
    public SpriteRenderer spriteRenderer;
    public GameObject UIContainer;
    public PlantGrid plantGrid;
    public GameObject aimReticle;

    public GameObject currentGun;
    public GameObject currentTroop;
    public GameObject currentPlant;
    public GameObject heldItem;
    

    // INPUT GLOBAL VARIABLES
    private PlayerInput playerInput;
    private bool inPlant;

    [SerializeField]
    public Vector2 movementInput = new(0f, 0f);

    [SerializeField]
    public Vector2 aimInput = new(0f, 0f);

    [SerializeField]
    public bool isPressedInteract, isPressedShoot, isPressedAimClockWise, isPressedAimCounterClockWise;


    // maybe these will come in useful later
    // private void OnEnable() { playerInput.enabled = true; }
    // private void OnDisable() { playerInput.enabled = false; }
    private void OnButtonPressed(ref bool button) { button = true; }
    private void OnButtonReleased(ref bool button) { button = false; }

    private void InitializeControls(PlayerInput playerInput_) {
        playerInput = playerInput_;

        InputAction Move = playerInput.actions["Move"];
        Move.performed += context => {
            movementInput = context.ReadValue<Vector2>();
        };
        Move.canceled += context => movementInput = new(0, 0);

        InputAction Interact = playerInput.actions["Interact"];
        Interact.started += context => {
            OnButtonPressed(ref isPressedInteract);
            if (!movementIsDisabled)
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
    public void OnPlayerJoined(PlayerInput playerInput_, GameObject enemyPlayer_, int playerNumber_) {

        playerNumber = playerNumber_;
        enemyPlayer = enemyPlayer_;

        // make player 2 face the correct way
        if (playerNumber == 2) {
            aimDirection = 180;
            CurrentDirection = Directions.left;
        }
        
        InitializeControls(playerInput_);
    }


    void Start() {
        currentHealth = maxHealth;
        setMoney(startingMoney);
        healthSlider.maxValue = (float)maxHealth;
        setHealth(maxHealth);

        defaultScale = transform.localScale;
    }


    public void Interact() {
        if(currentPlant.tag == "wheat"){
            if(inPlant == false && money >= currentPlant.GetComponent<WheatScript>().cost){
                GameObject newPlant = Instantiate(currentPlant, new Vector2(player.position.x, player.position.y), Quaternion.identity);
                setMoney(money - currentPlant.GetComponent<WheatScript>().cost);
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "wheat"){
            inPlant = true;
            if(collider.gameObject.GetComponent<WheatScript>().m >= 5){
                Destroy(collider.gameObject);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "wheat"){
            inPlant = false;
        }
    }

    public void disableMovement() { 
        movementIsDisabled = true; 
        player.velocity = new(0, 0);
    }
    public void enableMovement() { movementIsDisabled = false; }

    void Move() {
        velocity = new Vector2(movementInput.x, movementInput.y);
        player.velocity = new(velocity.x * moveSpeed * Time.deltaTime, velocity.y * moveSpeed * Time.deltaTime);

        if (movementInput.x > 0 && !movementIsDisabled) 
                CurrentDirection = Directions.right;

        if (movementInput.x < 0 && !movementIsDisabled) 
                CurrentDirection = Directions.left;
    

        if (isPressedAimClockWise)
            aimDirection = (aimDirection - aimSpeed * Time.deltaTime) % 360;
        
        if (isPressedAimCounterClockWise)
            aimDirection = (aimDirection + aimSpeed * Time.fixedDeltaTime) % 360;

        aimReticle.transform.eulerAngles = new(0, 0, aimDirection);
    }

    void ScalePlayer() {
        float scalingFactor = transform.position.y*zAxisScalingMultipler;
        float newYScale = defaultScale.y-scalingFactor;
        float newXScale;
        // Don't worry about this too much its just to patch up some unexpected behavior
        if (CurrentDirection == Directions.right) 
            newXScale = Math.Abs(defaultScale.x)-scalingFactor; 
        
        else 
            newXScale = -Math.Abs(defaultScale.x)+scalingFactor;
        
        transform.localScale = new(newXScale, newYScale, transform.localScale.z); 
    }



    private void FixedUpdate()
    {
        // Scales the player based on their y coordinate. 
        // This gives the illusion that the player is moving into the z axis
        ScalePlayer();
        
        if (!movementIsDisabled) Move();
    }

}
