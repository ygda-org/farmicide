using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float moveSpeed = 5f;
    //private Target _target;
    //private GameObject target;

    //private Rigidbody2D _rb;

    private GameObject plantManager;
    private GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        //_target = GetComponent<Target>();
        //_rb = GetComponent<Rigidbody2D>();
        ////target = _target.owner.gameObject;
        plantManager = GameObject.Find("PlantManager");
        owner = GetClosest();
    }

    // Update is called once per frame
    void Update()
    {
        PlantManager pManager = plantManager.GetComponent<PlantManager>();
        MoveTowardPlant(pManager.GetClosestPlant(transform.position, owner));
    }

    void MoveTowardPlant(GameObject plant)
    {
        GameObject targetPlant = plant;
        if (targetPlant != null)
        {
            float distance = Vector3.Distance(transform.position, targetPlant.transform.position);
            if (distance > 0.1f) // Adjust the threshold value as needed
            {
                Vector3 direction = (targetPlant.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                // The chicken has reached the target plant
                // Perform any desired actions or logic here
            }
        }
    }
    private GameObject GetClosest()
    {
        GameObject player_L = GameObject.Find("Player_L");
        GameObject player_R = GameObject.Find("Player_R");

        float distanceToPlayer_L = Vector3.Distance(transform.position, player_L.transform.position);
        float distanceToPlayer_R = Vector3.Distance(transform.position, player_R.transform.position);

        if (distanceToPlayer_L <= distanceToPlayer_R)
        {
            return player_L;
        }
        else
        {
            return player_R;
        }
    }
}
