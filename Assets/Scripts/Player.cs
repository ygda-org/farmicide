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

    public float turnSpeed = 0.1f, moveSpeed = 5f;
    public Vector2 moveDir = Vector2.right;
    private Rigidbody2D _rb;
    private PlayerGFX _playerGFX;
    private GameManager _manager;
    public Target target;

    private void Awake()
    {
        interactAction.performed += OnInteract;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerGFX = GetComponent<PlayerGFX>();
        target = GetComponent<Target>();
        target.owner = this;
        target.health = maxHealth;
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        interacting = interactAction.ReadValue<float>() > 0f;
        var turning = turnAction.ReadValue<float>();
        
        moveDir = (Quaternion.Euler(0f, 0f, -turnSpeed*turning*Time.deltaTime) * moveDir);
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
