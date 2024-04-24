using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        //Player = GetComponent<GameObject>();
    }
    void Update()
    {
        if (!Player.activeSelf)
        {
            RespawnDelay(3f);
        }
    }
    IEnumerator RespawnDelay(float delay)
    {
        yield return new WaitForSeconds (delay);
        Player.SetActive(true);
    }
}
