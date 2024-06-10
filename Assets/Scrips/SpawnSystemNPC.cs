using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystemNPC : MonoBehaviour
{
    [Header("-----NPC-----")]
    public Vector3 psNewRespawn;
    public Transform NPC;
    HealthcareSystemNPC healthcareSystemNPC;
    NPCroute NPCroute;
    bool isRespawningNPC;
    private void Start()
    {
        psNewRespawn = NPC.position;
        healthcareSystemNPC = GetComponent<HealthcareSystemNPC>();
        NPCroute = GetComponent<NPCroute>();
    }
    public void DeadNPC()
    {
        if (isRespawningNPC)
        {
            return;
        }
        StartCoroutine(respawnNPC());
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("New Respawn"))
        {
            psNewRespawn = collider.transform.position;
        }
    }
    IEnumerator respawnNPC()
    {
        isRespawningNPC = true;
        NPCroute.enabled = false;
        yield return new WaitForSeconds(3);
        NPC.position = psNewRespawn;
        NPCroute.enabled = true;
        NPCroute.maxNitro += 100;
        healthcareSystemNPC.Health += 100;
        isRespawningNPC = false;
    }
}