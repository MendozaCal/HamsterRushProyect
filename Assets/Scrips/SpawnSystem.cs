using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform posRespawn;
    public Transform posPlayer;
    public Vector3 psNewRespawn;
    public void DeadPlayer(bool isdead)
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
        yield return new WaitForSeconds(3);
        posPlayer.position = psNewRespawn;
    }
}