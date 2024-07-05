using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthcareSystemNPC : MonoBehaviour
{
    public float Health = 100;
    public float DamageFloor = 20;
    public float HealthRecuperation = 25;
    SpawnSystemNPC spawnSystemNPC;
    NPCroute NPCroute;
    public bool sueloVerify = false;
    private void Start()
    {
        spawnSystemNPC = GetComponent<SpawnSystemNPC>();
        NPCroute = GetComponent<NPCroute>();
    }
    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, 100);
        if (Health <= 0)
        {
            spawnSystemNPC.DeadNPC();
        }
        if (Health == 100)
        {
            NPCroute.maxSpeed = NPCroute.Speed;
            NPCroute.InicialSpeed = NPCroute.Speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            NPCroute.impulsoVerificationNPC = true;
            sueloVerify = true;
        }
        if (other.gameObject.CompareTag("Abismo"))
        {
            Health = 0;
            Debug.Log("abismo");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (sueloVerify = true && collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            sueloVerify = false;
            NPCroute.maxSpeed += 2f;
            NPCroute.InicialSpeed += 2f;
        }
        
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
            NPCroute.maxSpeed -= 2 * Time.deltaTime;
            NPCroute.InicialSpeed -= 2 * Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Borde"))
        {
            Health -= 50 * Time.deltaTime;
        }
    }
}
