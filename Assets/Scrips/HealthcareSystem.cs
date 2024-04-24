using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float Health = 21f;
    public float DamageFloor = 20f;
    public float HealthRecuperation = 25f;

    private void Update()
    {
        Health = Mathf.Min(Health, 100);//Limitar a Health a un máximo de 100

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Health -= DamageFloor;
            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    /*private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation;
        }
    }*/
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation * Time.deltaTime;
        }
    }
}
