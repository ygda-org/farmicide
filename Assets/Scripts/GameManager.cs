using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Application.targetFrameRate = 30;
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
