using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    [Header("-----Player-----")]
    public Transform posPlayer;
    public Vector3 psNewRespawn;
    HealthcareSystem healthcareSystem;
    PlayerController playerController;
    public Slider HealthSlider;
    bool isRespawning;
    GameObject spawn;

    private void Start()
    {
        healthcareSystem = GetComponent<HealthcareSystem>();
        playerController = GetComponent<PlayerController>();
        spawn = GameObject.FindWithTag("New Respawn");
    }

    public void DeadPlayer()
    {
        if (isRespawning)
        {
            return;
        }
        StartCoroutine(respawn());
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("New Respawn"))
        {
            psNewRespawn = collider.transform.position;
            spawn = collider.gameObject;
        }
    }
    IEnumerator respawn()
    {
        isRespawning = true;
        yield return new WaitForSeconds(3);
        posPlayer.position = psNewRespawn;
        posPlayer.transform.forward = spawn.transform.right;
        
        playerController.enabled = true;
        playerController.maxSpeed = playerController.Speed;
        playerController.incialSpeed = playerController.Speed;
        playerController.currentSpeed = 0;
        healthcareSystem.Health += 100;
        isRespawning = false;
    }
}