using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public Player owner
    {
        get
        {
            return GetComponent<Target>().owner;
        }
    }

    public float radius;

    private Territory _territory;
    // Start is called before the first frame update
    void Start()
    {
        _territory = FindObjectOfType<Territory>();
        _territory.Mark();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if(_territory) _territory.Mark();
    }
}
