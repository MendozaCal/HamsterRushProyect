using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthcareSystem : MonoBehaviour
{
    public float Health = 100;
    public float DamageFloor = 20;
    public float HealthRecuperation = 18.75f;
    public Slider HealthSlider;
    SpawnSystem spawnSystem;
    PlayerController playerController;
    public bool sueloVerifi = false;
    public bool isDamage = false;

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
            playerController.enabled = false;
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
            playerController.maxSpeed = playerController.Speed;
            playerController.incialSpeed= playerController.Speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (sueloVerifi == true && collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            sueloVerifi = false;
            playerController.maxSpeed += 2f;
            playerController.incialSpeed += 2f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
            HealthSlider.value = Health;
            if (playerController.maxSpeed > playerController.Speed && Health <= 100)
            {
                playerController.maxSpeed -= 2*Time.deltaTime;
                playerController.incialSpeed -=2*Time.deltaTime;
                if (Health == 100)
                {
                    playerController.maxSpeed = playerController.Speed;
                    playerController.incialSpeed = playerController.Speed;
                }
            }
        }
        if (collision.gameObject.CompareTag("Borde"))
        {
            Health -= 50 * Time.deltaTime;
        }
    }
    
}
