using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    public Transform posRespawn;
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
        yield return new WaitForSeconds(3);
        posPlayer.position = psNewRespawn;//La nueva posición de player será la del objeto trigger con tag "New Respawn"
        playerController.enabled = true;
        playerController.currentSpeed = 0;
        healthcareSystem.Health += 100;//Restablecer vida al aparecer
        HealthSlider.value = healthcareSystem.Health;//HUD
        isRespawning = false;
    }
}