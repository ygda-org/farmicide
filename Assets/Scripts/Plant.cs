using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float timeToHarvest = 5f;
    private float growTime = 0;
    
    public GameObject coinPf;
    public Vector2Int countRange;
    public float spawnRad;
    private Target _target;

    private Interactable _interactable;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        growTime += Time.deltaTime;
        _interactable.hint = growTime >= timeToHarvest ? "Harvest!" : "Growing...";
    }

    public void OnInteract(Player player)
    {
        if (growTime >= timeToHarvest)
        {
            for (int i = 0; i < Random.Range(countRange.x, countRange.y); i++)
            {
                var coin = Instantiate(coinPf, (Vector2)transform.position + Random.insideUnitCircle * spawnRad,
                    Quaternion.identity);
            }
            growTime = 0;
        }
    }
    
}
