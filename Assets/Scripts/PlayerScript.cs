using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 3;
    public Rigidbody2D player;
    private Vector2 velo;

    void Update()
    {
        input();
    }

    private void FixedUpdate()
    {
        move();
    }

    void input() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        velo = new Vector2(moveX, moveY);
    }

    void move() {
        player.velocity = new Vector2(velo.x * moveSpeed * Time.deltaTime, velo.y * moveSpeed * Time.deltaTime);
    }
}
