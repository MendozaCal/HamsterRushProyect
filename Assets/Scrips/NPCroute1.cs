using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCroute1 : MonoBehaviour
{
    //public TextMeshPro text;
    [Header("-----Move-----")]
    public Transform[] waypoints; 
    public float speed = 15;
    float InicialSpeed;
    private int currentWaypoint = 0;
    Rigidbody rb;
    public float gravity;

    [Header("-----Nitro-----")]
    public float maxNitro = 100;
    public float nitroPower = 10;
    public float nitroItem = 25;
    public float RandomDuration;
    public float RandomDelay;
    public float timerDuration = 0;
    public float timerDelay = 0;

    [Header("-----Impulso Rampa-----")]
    public float MaxTimeImpulso = 2;
    public float impulso = 10;
    float TimerImpulso = 0;
    public bool impulsoVerificationNPC = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InicialSpeed = speed;
        RandomDuration = Random.Range(10, 20);
        RandomDelay= Random.Range(3, 10);
    }
    void FixedUpdate()
    {
        speed = Mathf.Min(speed, InicialSpeed);
        maxNitro = Mathf.Clamp(maxNitro, 0, 100);
        /*if (text.text == $"Start")
        {*/
            //MoveToWaypoint();
        //}
        NitroNPC();
        calculateDistance();
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
        velocity.y = rb.velocity.y + (Physics.gravity.y * gravity * Time.deltaTime);
        rb.velocity = velocity;
        transform.LookAt(waypoints[currentWaypoint]);
    }
    void NitroNPC()
    {
        if (maxNitro > 0)
        {
            timerDelay += Time.deltaTime;
        }
        else
        {
            timerDelay = 0;
            timerDuration = 0;
        }
        if (maxNitro > 0 && impulsoVerificationNPC == false && timerDelay >= RandomDelay)
        {
            timerDuration += Time.deltaTime;
            UseNitro();
            if (timerDuration >= RandomDuration)
            {
                timerDelay = 0;
                timerDuration = 0;
                speed = InicialSpeed;
            }
        }
        else if (impulsoVerificationNPC == true)
        {
            BustRampa();
        }
        else
        {
            speed = InicialSpeed;
        }
    }
    public void BustRampa()
    {
        speed = InicialSpeed;
        speed += impulso;
        TimerImpulso += Time.deltaTime;
        if (TimerImpulso >= MaxTimeImpulso)
        {
            speed = InicialSpeed;
            impulsoVerificationNPC = false;
            TimerImpulso = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            impulsoVerificationNPC = true;
        }
        if (other.gameObject.CompareTag("Nitro"))
        {
            maxNitro += nitroItem;
        }
    }
    void UseNitro()
    {
        speed += nitroPower;
        maxNitro -= Time.deltaTime * 10;
    }
}
