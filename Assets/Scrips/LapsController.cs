using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapsController : PlayerController
{
    [Header("-----Cont Vueltas-----")]
    public TextMeshPro Contador;
    int laps = 1;
    public int MaxLaps = 3;
    public bool comprover1 = false;
    public bool comprover2 = false;
    public GameObject MetaFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meta"))
        {
            comprover1 = true;
            Contador.text = $"Lap {laps}/{MaxLaps}";
        }
        if (other.gameObject.CompareTag("Meta2"))
        {
            comprover2 = true;
            laps++;
        }
        if (comprover1 == true && comprover2 == true && laps < MaxLaps)
        {
            comprover1 = false;
            comprover2 = false;
        }
        if (laps > MaxLaps)
        {
            Contador.text = "Last Lap";
            MetaFinal.SetActive(true);
        }
        if (Contador.text == "Last Lap" && other.gameObject.CompareTag("FinalMeta"))
        {
            SceneManager.LoadScene("FinishScene");
        }
    }
}
