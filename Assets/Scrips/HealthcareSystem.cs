using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthcareSystem : MonoBehaviour
{
    public float Health = 100;
    public float DamageFloor = 20;
    public float HealthRecuperation = 25;
    public SpawnSystem spawnSystem;
    public Slider HealthSlider;
    private void Start()
    {
        HealthSlider.maxValue = Health;
    }
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
            HealthSlider.value = Health;
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
            HealthSlider.value = Health;
        }
    }
}
