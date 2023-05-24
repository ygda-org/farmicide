using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public Color defaultColor;
    public Marker closest;
    float dist = Single.MaxValue;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _sprite.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        var col = closest ? closest.owner.color : defaultColor;
        col.a = defaultColor.a;
        _sprite.color = col;
    }

    public void Recompute(Marker[] markers)
    {
        closest = null;
        dist = float.MaxValue;
        foreach (var marker in markers)
        {
            var sqm = (marker.transform.position - transform.position).sqrMagnitude;
            if (sqm < dist)
            {
                closest = marker;
                dist = sqm;
            }
        }

        if (closest && Mathf.Pow(dist, 2) >= closest.radius)
        {
            closest = null;
        }
    }
}
