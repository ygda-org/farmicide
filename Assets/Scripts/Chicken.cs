using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Target _target;
    private GameObject target;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _rb = GetComponent<Rigidbody2D>();
        target = _target.owner.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = (target.transform.position - transform.position);
        if (dir.magnitude > 2f)
        {
            _rb.velocity = dir.normalized * moveSpeed; // move toward
        }
        else if (dir.magnitude > 1f)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = -dir.normalized * moveSpeed; // move away
        }
    }
}
