using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTerritoryBar : MonoBehaviour
{
    public Slider left;

    private TutorialGameManager _manager;
    private Territory _territory;
    // Start is called before the first frame update
    void Start()
    {
        _territory = FindObjectOfType<Territory>();
        _manager = FindObjectOfType<TutorialGameManager>();
        print(left);
    }

    // Update is called once per frame
    void Update()
    {
        left.value = _manager.leftTerritory;
    }
}
