using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform posRespawn;
    public Transform posPlayer;
    public Vector3 psNewRespawn;
    public HealthcareSystem healthcareSystem;
    public PlayerController playerController;
    public void DeadPlayer()
    {
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
        playerController.enabled = false;
        yield return new WaitForSeconds(3);
        posPlayer.position = psNewRespawn;
        healthcareSystem.Health += 100;
        playerController.enabled = true;
    }
}