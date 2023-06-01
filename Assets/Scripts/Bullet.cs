using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public Player owner;
    public float speed = 5f;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Target target;
        if (other.gameObject.TryGetComponent(out target))
        {
            if (target.owner == owner) return; // if same owner, pass through
            target.TakeDamage(damage);
            Destroy();
        }
    }
    
    void Destroy()
    {
        Destroy(gameObject);
    }
}
