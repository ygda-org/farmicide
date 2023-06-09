using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    
    public Color color;
    public int money;
    public GameObject bag;
    public Interactable focus;

    public float interactHold = 0f, interactTimer = 0f;
    public float interactDelay = 0f, interactDelayTimer = 0f;
    public float UIPopUpBuffer = 0f, UIPopUpBufferTimer = 0f;

    public InputAction interactAction;
    public InputAction turnAction;
    public bool interactIsDisabled = false;

    public float moveSpeed = 5f;
    public Vector2 moveDir;
    private Rigidbody2D _rb;
    private PlayerGFX _playerGFX;
    private GameManager _manager;
    public Target target;

    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerGFX = GetComponent<PlayerGFX>();
        target = GetComponent<Target>();
        target.owner = this;
        target.health = maxHealth;
        _manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // basic movement

        moveDir = turnAction.ReadValue<Vector2>().normalized;
        _rb.velocity = moveDir * moveSpeed;

        if (interactIsDisabled) return;


        // interaction handler

        if (interactDelayTimer <= 0)
            interactTimer = interactAction.ReadValue<float>() > 0f ? interactTimer + Time.deltaTime : 0f;
            if (interactTimer == 0f) 
                UIPopUpBufferTimer = UIPopUpBuffer;


        if (interactTimer > interactHold)
        {
            interactTimer = 0f;
            OnInteract();
            interactDelayTimer = interactDelay;
        }
        
        if(focus) 
            _playerGFX.DisplayUI();

        if (interactTimer > 0f && UIPopUpBufferTimer <= 0)
            _playerGFX.DisplayUI();
        else if (interactAction.ReadValue<float>() == 0)
            _playerGFX.InteruptUI();


        interactDelayTimer--;
        UIPopUpBufferTimer--;


    }

    void OnInteract()
    {
        if (focus)
        {
            focus.onInteract.Invoke(this);
        } else if (bag)
        {
            var obj = Instantiate(bag, transform.position, Quaternion.identity);
            var tobj = obj.GetComponent<Target>();
            if (tobj) tobj.owner = this;
            
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

    public void AddMoney(int amount)
    {
        money += amount;
    }
    
    private void OnEnable()
    {
        interactAction.Enable();
        turnAction.Enable();
    }

    // private void OnDestroy()
    // {
    //     _manager.LoseGame(this);
    // }
}
