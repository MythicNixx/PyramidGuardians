﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public int damage = 50;

    public void Seek(Transform enemyTarget)
    {
        target = enemyTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
                return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);

        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(explosionRadius > 0)
        {
            Explode();
        }

        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(Collider collider in colliders)
            {
                if(collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }

    void Damage(Transform enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);
        }
    }

    
}
