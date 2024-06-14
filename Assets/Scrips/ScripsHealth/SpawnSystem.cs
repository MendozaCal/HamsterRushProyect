using System.Collections;
using System.Collections.Generic;
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
    private void Start()
    {
        healthcareSystem = GetComponent<HealthcareSystem>();
        playerController = GetComponent<PlayerController>();
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
        }
    }
    IEnumerator respawn()
    {
        isRespawning = true;
        yield return new WaitForSeconds(4);
        posPlayer.position = psNewRespawn;
        playerController.enabled = true;
        playerController.maxSpeed = playerController.Speed;
        playerController.incialSpeed = playerController.Speed;
        healthcareSystem.Health += 100;
        isRespawning = false;
    }
}