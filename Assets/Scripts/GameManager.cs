using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player leftPlayer, rightPlayer;
    public float leftTerritory, rightTerritory;
    public bool ended = false;
    private Territory _territory;

    private void Start()
    {
        _territory = FindObjectOfType<Territory>();
    }

    private void Update()
    {
        var total = _territory.dims.x * _territory.dims.y;
        leftTerritory = _territory.marked[leftPlayer] / (total*1f);
        rightTerritory = _territory.marked[rightPlayer] / (total * 1f);

        if (_territory.marked[leftPlayer] == total)
        {
            LoseGame(rightPlayer);
        } else if (_territory.marked[rightPlayer] == total)
        {
            LoseGame(leftPlayer);
        }
    }

    public void LoseGame(Player loser)
    {
        ended = true;
        Player winner = leftPlayer == loser ? rightPlayer : leftPlayer;
        Debug.Log(winner + " beat " + loser + " !");
    }
    
}
