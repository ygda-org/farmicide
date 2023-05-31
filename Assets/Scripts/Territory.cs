using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Territory : MonoBehaviour
{
    public GameObject plot;
    public Vector2 dims; // (x = width, y = height)
    public Dictionary<Player, int> marked;
    public Vector2 tileSize = new Vector2(1f, 1f);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(dims.x, dims.y, 0.1f));
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        marked = new Dictionary<Player, int>();
        Mark();
    }

    void Spawn()
    {
        for (int i = 0; i < dims.y/tileSize.y; i++)
        {
            for (int j = 0; j < dims.x/tileSize.x; j++)
            {
                var p = Instantiate(plot, new Vector3(TileNumToCoord(j, dims.x, tileSize.x), TileNumToCoord(i, dims.y, tileSize.y), 0), Quaternion.identity, transform);
                p.transform.localScale = new Vector3(tileSize.x, tileSize.y, 1f);
            }
        }
    }
    
    float TileNumToCoord(int num, float dim, float tileSize)
    {
        return tileSize*(num - (Mathf.Floor(dim/tileSize) - 1) / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mark()
    {
        var markers = FindObjectsOfType<Marker>();
        foreach (var player in FindObjectsOfType<Player>())
        {
            marked[player] = 0;
        }
        
        foreach (var plot in GetComponentsInChildren<Plot>())
        {
            plot.Recompute(markers);
            if (plot.closest)
            {
                marked[plot.closest.owner]++;
            }
        }
    }
}
