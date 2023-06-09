using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    public int cost = 10;
    public GameObject item;

    public void Buy(Player player)
    {
        if (player.money < cost) return;
        if (player.bag) return; // can't buy if currently carrying something
        
        player.money -= cost;
        player.bag = item;
    }
}
