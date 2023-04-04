using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// implement the chicken charging and dashing into the enemy player
public class Chicken : MonoBehaviour
{
    public int target = 0;

    public GameObject enemyPlayer;
    // public Transform enemyTrans;
    // public Transform player;
    public float radius = 3;
    bool playerDetected = false;

    public float moveSpeed = 4;
    public double damage;
    
    public int chargeTime;
    public int attackTime;
    public int coolDown;
    
    private Vector3 currentTarget;
    private int chargeTimeElapsed;
    private int attackTimeElapsed;
    private int coolDownTimeElapsed;


    public enum states {
        idle,
        charging,
        attacking,
        coolDown,
    };

    public states currentState;

    public void initializeChicken(GameObject enemyPlayer_) {
        enemyPlayer = enemyPlayer_;
    }

    private void lockOntoTarget() {
        Vector2 chickenPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 enemyPlayerPosition = new Vector2(enemyPlayer.transform.position.x, enemyPlayer.transform.position.y);
        
        if (Vector2.Distance(chickenPosition, enemyPlayerPosition) <= radius) {
            currentTarget = enemyPlayer.transform.position;
            currentState = states.charging;
        }
        
    }

    void FixedUpdate() {
        
        if (currentState == states.idle) 
            lockOntoTarget();
        
        if (currentState == states.charging) {
            chargeTimeElapsed++;
            if (chargeTime <= chargeTimeElapsed) {
                chargeTimeElapsed = 0;
                currentState = states.attacking;
            }
        }

        if (currentState == states.attacking) {
            Vector3 dir = (currentTarget - transform.position).normalized;

            this.gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + dir * moveSpeed* Time.fixedDeltaTime);

            attackTimeElapsed++;
            if (attackTime <= attackTimeElapsed) {
                attackTimeElapsed = 0;
                currentState = states.coolDown;
            }

        }
        
        if (currentState == states.coolDown) {
            coolDownTimeElapsed++;
            if (coolDown <= coolDownTimeElapsed) {
                coolDownTimeElapsed = 0;
                currentState = states.idle;
            }
        }


    }
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject == enemyPlayer) {
            PlayerScript enemyPlayerScript = collider.gameObject.GetComponent<PlayerScript>();   
            enemyPlayerScript.setHealth(enemyPlayerScript.getHealth()-damage);
            Destroy(this.gameObject);
        }
    }


    // void Update()
    // {
    //     Vector2 enemyPos = new Vector2(enemyTrans.position.x, enemyTrans.position.y);
    //     RaycastHit2D ray = Physics2D.CircleCast(enemyPos, radius, new Vector2(0,0), 0);
    //     if (ray.collider != null)
    //     {
    //         if (target == 0)
    //         {
    //             if (ray.collider.name == "Player1") playerDetected = true;
    //         }
    //         else if (target == 1)
    //         {
    //             if (ray.collider.name == "Player2") playerDetected = true;
    //         }
    //     }
    //     else playerDetected = false;
    //     if (playerDetected == true)
    //     {
    //         Debug.Log("player detected");
    //         Vector3 dir = (player.transform.position - enemyRb.transform.position).normalized;
    //         enemyRb.MovePosition(enemyRb.transform.position + dir * moveSpeed* Time.fixedDeltaTime);
    //     }
    // }

}
