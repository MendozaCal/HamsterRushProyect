using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNitro : MonoBehaviour
{
    public GameObject Nitro;
    public Collider NitroCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            StartCoroutine(ToggleObject());
        }   
    }
    IEnumerator ToggleObject()
    {
        Nitro.SetActive(false);
        NitroCollider.enabled = false;
        yield return new WaitForSeconds(5);
        Nitro.SetActive(true);
        NitroCollider.enabled = true;
    }
}
