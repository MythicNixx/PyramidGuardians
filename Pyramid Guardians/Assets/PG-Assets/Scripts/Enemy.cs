using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 20f;
    public Transform target;
    public int wavePointIndex = 0;
    public PlayerStats playerStats;
    public int health = 100;

    private void Start()
    {
        target = WayPoints.points[wavePointIndex];
        playerStats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStats>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {
            EndReached();
            return;
        }

        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void EndReached()
    {
        playerStats.SubtractLives();
        Destroy(gameObject);
    }


}
