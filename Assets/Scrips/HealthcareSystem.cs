using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int Health = 21;
    public int DamageFloor = 20;
    public int HealthRecuperation = 25;

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
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pits"))
        {
            Health += HealthRecuperation;
        }
    }
}
