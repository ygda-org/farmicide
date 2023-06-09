using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public Player leftPlayer, rightPlayer;
    public float leftTerritory, rightTerritory;

    public GameObject endGameCanvas;
    public TextMeshProUGUI endGameText;
    
    public bool ended = false;
    private Territory _territory;

    private void Start()
    {
        _territory = FindObjectOfType<Territory>();
        endGameCanvas.SetActive(false);
    }

    private void Update()
    {
        var total = (int)(_territory.dims.x / _territory.tileSize.x) * (int)(_territory.dims.y / _territory.tileSize.y);
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
        Time.timeScale = 0f;
        ended = true;
        Player winner = leftPlayer == loser ? rightPlayer : leftPlayer;
        endGameText.text =  winner + " beat " + loser + " !";
        endGameCanvas.SetActive(true); // TODO: animate this 

    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
