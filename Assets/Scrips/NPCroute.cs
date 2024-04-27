using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCroute : MonoBehaviour
{
    public Transform[] waypoints; 
    public float speed = 5;
    private int currentWaypoint = 0;

    void Update()
    {
        calculateDistance();
        MoveToWaypoint();
    }
    void calculateDistance()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.5f)
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

        transform.position += direction * speed * Time.deltaTime;

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
