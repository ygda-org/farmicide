using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory : MonoBehaviour
{
    public GameObject plot;
    public Dictionary<Player, int> marked;
    public Vector2Int dims;
    // Start is called before the first frame update
    void Start()
    {
        marked = new Dictionary<Player, int>();
        for (int i = 0; i < dims.y; i++)
        {
            for (int j = 0; j < dims.x; j++)
            {
                Instantiate(plot, new Vector3((j-(dims.x-1)/2f), (i-(dims.y-1)/2f), 0), Quaternion.identity, transform);
            }
        }
        
        Mark();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mark()
    {
        foreach (var player in FindObjectsOfType<Player>())
        {
            marked[player] = 0;
        }
        
        foreach (var plot in GetComponentsInChildren<Plot>())
        {
            plot.Recompute();
            if (plot.closest)
            {
                marked[plot.closest.owner]++;
            }
        }
    }
}
