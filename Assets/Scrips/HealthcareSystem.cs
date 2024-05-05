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
    private void Start()
    {
        //HealthSlider.maxValue = Health;
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
        if (collision.gameObject.CompareTag("Abismo"))
        {
            Health = 0;
            HealthSlider.value = Health;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Impulso"))
        {
            playerController.impulsoVerification = true;
            HealthSlider.value = Health;
            StartCoroutine(Cont());
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
    IEnumerator Cont()
    {
        yield return new WaitForSeconds(1);
        Health -= DamageFloor;
    }
}
