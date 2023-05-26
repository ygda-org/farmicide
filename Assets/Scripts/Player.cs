using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    
    public Color color;
    public float money;
    public GameObject bag;
    public Interactable focus;

    public bool interacting;
    
    public InputAction interactAction;
    public InputAction turnAction;
    public bool isTurningDiagonal;

    public float turnSpeed = 0.1f, moveSpeed = 5f;
    public Vector2 moveDir = Vector2.right;
    private Rigidbody2D _rb;
    private PlayerGFX _playerGFX;
    private GameManager _manager;
    public Target target;

    private void Awake()
    {
        interactAction.performed += OnInteract;
        turnAction.performed += OnTurn;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerGFX = GetComponent<PlayerGFX>();
        target = GetComponent<Target>();
        target.owner = this;
        target.health = maxHealth;
        _manager = FindObjectOfType<GameManager>();
        moveDir = new(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.velocity = moveDir * moveSpeed;
        
        if(focus) _playerGFX.DisplayUI();
    }

    void OnInteract(InputAction.CallbackContext ctx)
    {
        if (focus)
        {
            focus.onInteract.Invoke(this);
        } else if (bag)
        {
            var obj = Instantiate(bag, transform.position, Quaternion.identity);
            obj.GetComponent<Target>().owner = this;
            
            bag = null;
        }

        interacting = interactAction.ReadValue<float>() > 0f;
    }

    void OnTurn(InputAction.CallbackContext ctx)
    {
        var turning = turnAction.ReadValue<Vector2>();  

        if (turning != Vector2.zero && ((isTurningDiagonal && turning == Vector2.zero) || !isTurningDiagonal)) {
            moveDir = new(turning.x, turning.y);
        }

        if (turning.x != 0 && turning.y != 0)
            isTurningDiagonal = true;
        else isTurningDiagonal = false;

    }

    public void Focus(Interactable interactable)
    {
        focus = interactable;
    }

    public void TakeDamage(float damage)
    {
        _playerGFX.DisplayUI();
    }

    public void AddMoney(float amount)
    {
        money += amount;
    }
    
    private void OnEnable()
    {
        interactAction.Enable();
        turnAction.Enable();
    }

    private void OnDestroy()
    {
        _manager.LoseGame(this);
    }

    void OnTriggerEnter2D(Collider2D collisionData) 
    {
        if (collisionData.gameObject.tag == "VerticalBorder") 
            moveDir = new(moveDir.x, -moveDir.y);
        if (collisionData.gameObject.tag == "HorizontalBorder")
            moveDir = new(-moveDir.x, moveDir.y);
    }
}
