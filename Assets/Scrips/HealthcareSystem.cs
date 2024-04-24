using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float Health = 21f;
    public float DamageFloor = 20f;
    public float HealthRecuperation = 25f;
    public GameObject[] Spawners;
    public Transform Spawn;

    private void Update()
    {
        Health = Mathf.Min(Health, 100);//Limitar a Health a un máximo de 100
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            RespawnDelay(3);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            
        }
    }
    IEnumerator RespawnDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(true);
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
        }   
    }
}
