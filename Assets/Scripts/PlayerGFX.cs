using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGFX : MonoBehaviour
{
    public GameObject movementArrow;
    public GameObject ui;
    public Slider healthSlider;
    public TextMeshProUGUI interactionHint, bagHint, money;
    
    public float idleTime = 1f;
    public float idleTimer;
    public float visibilitySpring = 2f;
    private float _desiredVisibility = 0f, _visibility = 0f;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        movementArrow.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(_player.moveDir.y, _player.moveDir.x)*Mathf.Rad2Deg);
        healthSlider.value = _player.target.health/_player.maxHealth;

        idleTimer += Time.deltaTime;
        if (idleTimer > idleTime)
        {
            _desiredVisibility = 0f;
        }

        _visibility = Mathf.Lerp(_visibility, _desiredVisibility, Time.deltaTime*visibilitySpring);
        ui.transform.localScale = _visibility * (new Vector3(1, 1, 1));

        interactionHint.text = _player.focus ? _player.focus.hint : "";
        bagHint.text = "Bag: " + (_player.bag ? _player.bag.name : "(empty)");
        money.text = "$ " + _player.money.ToString();
    }

    public void DisplayUI()
    {
        _desiredVisibility = 1f;
        idleTimer = 0f;
    }
}
