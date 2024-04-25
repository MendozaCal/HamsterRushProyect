using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform posRespawn;
    public Transform posPlayer;
    public bool isRes = false;

    public void DeadPlayer()
    {
        StartCoroutine(respawn());
    }
    IEnumerator respawn()
    {
        yield return new WaitForSeconds(3);
        posPlayer.position = posRespawn.position;
        isRes = true;
    }
}
