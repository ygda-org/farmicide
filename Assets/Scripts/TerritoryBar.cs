using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerritoryBar : MonoBehaviour
{
    public Slider left, right;

    public Player leftPlayer, rightPlayer;

    private Territory _territory;
    // Start is called before the first frame update
    void Start()
    {
        _territory = FindObjectOfType<Territory>();
    }

    // Update is called once per frame
    void Update()
    {
        var total = _territory.dims.x * _territory.dims.y;
        left.value = _territory.marked[leftPlayer] / (total*1f);
        right.value = _territory.marked[rightPlayer] / (total * 1f);
    }
}
