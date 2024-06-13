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
        Health = Mathf.Min(Health, 100); // Limitar a Health a un máximo de 100
        Health = Mathf.Max(Health, 0);
        if (Health <= 0)
        {
            spawnSystemNPC.DeadNPC();
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
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (sueloVerify = true && collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            sueloVerify = false;
        }

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
        }
    }
}
