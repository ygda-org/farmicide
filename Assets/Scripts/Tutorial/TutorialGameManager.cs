using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGameManager : MonoBehaviour
{
    public Player leftPlayer;
    public float leftTerritory;

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


        if (Input.GetKeyDown("escape")) 
            SceneManager.LoadScene("Main Menu");

    }

    
}
