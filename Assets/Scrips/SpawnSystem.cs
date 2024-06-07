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
    public HealthcareSystem healthcareSystem;
    public PlayerController playerController;
    public Slider HealthSlider;
    bool isRespawning;
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
        playerController.enabled = false;
        yield return new WaitForSeconds(5);
        posPlayer.position = psNewRespawn;
        playerController.enabled = true;
        healthcareSystem.Health += 100;
        isRespawning = false;
    }
}