using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerritoryBar : MonoBehaviour
{
    public Slider left, right;

    private GameManager _manager;
    private Territory _territory;
    // Start is called before the first frame update
    void Start()
    {
        _territory = FindObjectOfType<Territory>();
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        left.value = _manager.leftTerritory;
        right.value = _manager.rightTerritory;
    }
}
