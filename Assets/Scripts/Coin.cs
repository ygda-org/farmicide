using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public Player[] players;
    public float attractRad = 5f, attractForce = 5f;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        players = FindObjectsOfType<Player>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        foreach (var player in players)
        {
            var dir = player.transform.position - transform.position;
            if (dir.sqrMagnitude > attractRad * attractRad) continue;
            _rb.AddForce(dir*attractForce/dir.sqrMagnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (other.TryGetComponent(out player))
        {
            player.AddMoney(value);
            Destroy(gameObject); // TODO: collection effect
        }
    }
}
