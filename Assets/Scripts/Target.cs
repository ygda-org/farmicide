using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TargetDamageEvent : UnityEvent<float> {}

public class Target : MonoBehaviour
{
    public Player owner;

    public float health;
    public TargetDamageEvent onDamage;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0) Destroy(gameObject);
        onDamage.Invoke(damage);
    }
}
