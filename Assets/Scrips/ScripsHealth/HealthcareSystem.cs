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
    public GameObject particles;
    [Header("-----Estados Esfera-----")]
    public GameObject Esfera1;
    public GameObject Esfera2;
    public GameObject Esfera3;
    public GameObject Esfera4;
    public GameObject Esfera5;
    public GameObject Esfera6;

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
        if (Health >= 100)
        {
            Esfera1.SetActive(true);
            Esfera2.SetActive(false);
            Esfera3.SetActive(false);
            Esfera4.SetActive(false);
            Esfera5.SetActive(false);
            Esfera6.SetActive(false);
        }
        if (Health < 100 && Health >= 80)
        {
            Esfera1.SetActive(false);
            Esfera2.SetActive(true);
            Esfera3.SetActive(false);
            Esfera4.SetActive(false);
            Esfera5.SetActive(false);
            Esfera6.SetActive(false);
        }
        if (Health < 80 && Health >= 60)
        {
            Esfera1.SetActive(false);
            Esfera2.SetActive(false);
            Esfera3.SetActive(true);
            Esfera4.SetActive(false);
            Esfera5.SetActive(false);
            Esfera6.SetActive(false);
        }
        if (Health < 60 && Health >= 40)
        {
            Esfera1.SetActive(false);
            Esfera2.SetActive(false);
            Esfera3.SetActive(false);
            Esfera4.SetActive(true);
            Esfera5.SetActive(false);
            Esfera6.SetActive(false);
        }
        if (Health < 40 && Health >= 20)
        {
            Esfera1.SetActive(false);
            Esfera2.SetActive(false);
            Esfera3.SetActive(false);
            Esfera4.SetActive(false);
            Esfera5.SetActive(true);
            Esfera6.SetActive(false);
        }
        if (Health < 20 && Health >= 0)
        {
            Esfera1.SetActive(false);
            Esfera2.SetActive(false);
            Esfera3.SetActive(false);
            Esfera4.SetActive(false);
            Esfera5.SetActive(false);
            Esfera6.SetActive(true);
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
            sueloVerifi = false;
        }
        if (other.gameObject.CompareTag("Pits") && Health < 100)
        {
            particles.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pits"))
        {
            particles.SetActive(false);
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
            HealthSlider.value = Health;
            if (playerController.maxSpeed > playerController.Speed && Health <= 100)
            {
                playerController.maxSpeed -= 2*Time.deltaTime;
                playerController.incialSpeed -=2*Time.deltaTime;
                if (Health <= 100)
                {
                    playerController.maxSpeed = playerController.Speed;
                    playerController.incialSpeed = playerController.Speed;
                }
            }
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
