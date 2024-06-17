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
    GameObject spawn;
    private void Start()
    {
        healthcareSystem = GetComponent<HealthcareSystem>();
        playerController = GetComponent<PlayerController>();
        spawn = GameObject.FindWithTag("New Respawn");
    }
    private void Update()
    {
        if (posPlayer.transform.rotation == spawn.transform.rotation)
        {
            Debug.Log("funciona");
        }
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
        posPlayer.transform.rotation = spawn.transform.rotation;
        
        playerController.enabled = true;
        playerController.maxSpeed = playerController.Speed;
        playerController.incialSpeed = playerController.Speed;
        healthcareSystem.Health += 100;
        isRespawning = false;
    }
}