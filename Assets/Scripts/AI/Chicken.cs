using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// implement the chicken charging and dashing into the enemy player
public class Chicken : MonoBehaviour
{
    public int target = 0;

    public Rigidbody2D enemyRb;
    public Transform enemyTrans;
    public Transform player;
    public float radius = 3;
    bool playerDetected = false;

    public float moveSpeed = 2;
    public float chargeTime;
    public float coolDown;
    public double damage;
    
    private Vector2 currentTarget;
    

    // private void lockOntoTarget() {
    //     Vector2 enemyPos = new Vector2(enemyTrans.position.x, enemyTrans.position.y);
    //     RaycastHit2D ray = Physics2D.CircleCast(enemyPos, radius, new Vector2(0,0), 0);
    //     if (ray.collider != null) {
    //         if target
    //     }
    // }

    void Update()
    {
        Vector2 enemyPos = new Vector2(enemyTrans.position.x, enemyTrans.position.y);
        RaycastHit2D ray = Physics2D.CircleCast(enemyPos, radius, new Vector2(0,0), 0);
        if (ray.collider != null)
        {
            if (target == 0)
            {
                if (ray.collider.name == "Player1") playerDetected = true;
            }
            else if (target == 1)
            {
                if (ray.collider.name == "Player2") playerDetected = true;
            }
        }
        else playerDetected = false;
        if (playerDetected == true)
        {
            Debug.Log("player detected");
            Vector3 dir = (player.transform.position - enemyRb.transform.position).normalized;
            enemyRb.MovePosition(enemyRb.transform.position + dir * moveSpeed* Time.fixedDeltaTime);
        }
    }

}
