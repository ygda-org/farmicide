using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    public float cost = 10f;
    public GameObject item;

    public void Buy(Player player)
    {
        if (player.money < cost) return;
        
        player.money -= cost;
        player.bag = item;
    }
}
