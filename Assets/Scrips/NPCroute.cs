using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCroute : MonoBehaviour
{
    public Transform[] waypoints; 
    public float speed = 15;
    private int currentWaypoint = 0;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        calculateDistance();
        MoveToWaypoint();
    }
    void calculateDistance()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 1)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
    void MoveToWaypoint()
    {
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction.Normalize();
        Vector3 velocity = direction * speed;
        rb.velocity = velocity;
        transform.LookAt(waypoints[currentWaypoint]);
    }
    /*void NitroNPC()
    {
        float RandomValor = Random.RandomRange(0,10);
        if(RandomValor >= 6 && RandomValor <= 8)
        {
            
        }
    }*/
}
