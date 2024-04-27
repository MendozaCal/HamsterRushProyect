using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthcareSystem : MonoBehaviour
{
    public float Health = 21f;
    public float DamageFloor = 20f;
    public float HealthRecuperation = 25f;
    //public PlayerController playerController;
    public SpawnSystem spawnSystem;
    private void Update()
    {
        Health = Mathf.Min(Health, 100); // Limitar a Health a un máximo de 100
        Health = Mathf.Max(Health, 0);
        if (Health <= 0)
        {
            spawnSystem.DeadPlayer();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
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
