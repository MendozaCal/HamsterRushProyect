using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroProcedural : MonoBehaviour
{
    public GameObject[] LineNitro;
    public int randomIndex;
    void Start()
    {
        ShowItem();
        
    }
    void ShowItem()
    {
        randomIndex = Random.Range(0, LineNitro.Length);

        if (randomIndex < LineNitro.Length)
        {
            GameObject itemToActivate = LineNitro[randomIndex];
            if (itemToActivate != null)
            {
                itemToActivate.SetActive(true);
            }
        }
        
    }
}
