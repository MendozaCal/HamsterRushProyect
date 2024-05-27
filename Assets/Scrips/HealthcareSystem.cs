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
    public PlayerController playerController;
    public bool sueloVerifi = false;

    private void Start()
    {
        HealthSlider.maxValue = Health;
        HealthSlider.interactable = false;
    }
    private void Update()
    {
        Health = Mathf.Min(Health, 100); // Limitar a Health a un máximo de 100
        Health = Mathf.Max(Health, 0);
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
    IEnumerator Cont()
    {
        yield return new WaitForSeconds(1);
    }
}
