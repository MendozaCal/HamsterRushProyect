using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCroute : MonoBehaviour
{
    [Header("-----Move-----")]
    public Transform[] waypoints; 
    public float speed = 15;
    float InicialSpeed;
    private int currentWaypoint = 0;
    Rigidbody rb;

    [Header("-----Nitro-----")]
    public float maxNitro = 100;
    public float nitroPower = 10;
    public float nitroItem = 25;
    public float RandomValor;
    public float Timer = 0;

    [Header("-----Impulso Rampa-----")]
    public float MaxTimeImpulso = 2;
    public float impulso = 10;
    float TimerImpulso = 0;
    bool impulsoVerification = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InicialSpeed = speed;
    }
    void FixedUpdate()
    {
        speed = Mathf.Min(speed, InicialSpeed);
        maxNitro = Mathf.Max(maxNitro, 0);
        maxNitro = Mathf.Min(maxNitro, 100);

        calculateDistance();
        MoveToWaypoint();
        NitroNPC();
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
    void NitroNPC()
    {
        if (maxNitro > 0 && impulsoVerification == false)
        {
            RandomValor = Random.Range(0, 10);
            if (RandomValor == 1)
            {
                speed += nitroPower;
                StartCoroutine(UseNitro());
            }
        }
        else if (impulsoVerification == true)
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
            impulsoVerification = false;
            TimerImpulso = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            impulsoVerification = true;
        }
        if (other.gameObject.CompareTag("Nitro"))
        {
            maxNitro += nitroItem;
        }
    }
    IEnumerator UseNitro()
    {
        maxNitro -= Time.deltaTime * 10;
        yield return new WaitForSeconds(5);
        speed = InicialSpeed;
    }
}
