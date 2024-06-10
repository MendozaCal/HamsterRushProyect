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
    public Slider HealthSlider;
    SpawnSystem spawnSystem;
    PlayerController playerController;
    public bool sueloVerifi = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        spawnSystem = GetComponent<SpawnSystem>();
        HealthSlider.maxValue = Health;
        HealthSlider.interactable = false;
    }
    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, 100);
        HealthSlider.value = Health;
        if (Health <= 0)
        {
            spawnSystem.DeadPlayer();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            playerController.impulsoVerification = true;
            sueloVerifi = true;
            
        }
        if (other.gameObject.CompareTag("Abismo"))
        {
            Health = 0;
            HealthSlider.value = Health;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (sueloVerifi == true && collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            sueloVerifi = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime * 0.75f;
            HealthSlider.value = Health;
        }
        if (collision.gameObject.CompareTag("Borde"))
        {
            Health -= 50 * Time.deltaTime;
        }
    }
    
}
