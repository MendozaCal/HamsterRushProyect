using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int Health = 100;
    public int DamageFloor = 20;
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
}
