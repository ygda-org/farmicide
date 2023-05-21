using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Target target;
    public GameObject bullet;
    public Transform shootPoint, gun;
    public float reloadTime = 1f;
    
    private bool canShoot = true;
    private Target _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            var dir = target.transform.position-transform.position;
            gun.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg);
            if (canShoot) Shoot();
        }
        else
        {
            FindTarget();
        }
    }

    void Shoot()
    {
        if (!canShoot) return;
        var b = Instantiate(bullet, shootPoint.position, Quaternion.identity, transform);
        b.transform.rotation = gun.rotation;
        
        canShoot = false;
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    void FindTarget()
    {
        Debug.Log("finding target" +  _target.owner + "is my dad");
        target = null;
        var dist = float.MaxValue;

        foreach (var t in FindObjectsOfType<Target>())
        {
            if (t.owner != _target.owner)
            {
                var sqm = (t.transform.position - transform.position).sqrMagnitude;
                if (sqm < dist)
                {
                    target = t;
                    dist = sqm;
                }
            }
        }
    }
}
