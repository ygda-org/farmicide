using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Target target;
        if (other.gameObject.TryGetComponent(out target))
        {
            target.TakeDamage(damage);
        }
        
        Destroy();
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
