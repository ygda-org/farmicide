using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float value;
    
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
