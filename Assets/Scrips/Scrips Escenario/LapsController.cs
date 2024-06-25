using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapsController : MonoBehaviour
{
    [Header("-----Cont Vueltas-----")]
    public TextMeshPro Contador;
    float cont = 1;
    public int laps = 0;
    public int MaxLaps = 3;
    public bool comprover1 = false;
    public bool comprover2 = false;
    public GameObject MetaFinal;
    PlayerController playerController;
    NPCroute[] NPCroute;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.enabled = false;
        NPCroute = FindObjectsOfType<NPCroute>();
        foreach (NPCroute npcRoute in NPCroute)
        {
            npcRoute.enabled = false;
        }
    }
    private void Update()
    {
        StartController();
    }
    void StartController()
    {
        cont += Time.deltaTime * 0.5f;
        float contadorRedondeado = Mathf.Round(cont);
        Contador.text = contadorRedondeado.ToString();
        if (cont >= 3)
        {
            Contador.text = $"Start";
            playerController.enabled = true;
            foreach (NPCroute npcRoute in NPCroute)
            {
                npcRoute.enabled = true;
            }
            if (cont >= 5)
            {
                Contador.text = $"Lap {laps}/{MaxLaps}";
            }
        }
        if (comprover1 == true && comprover2 == true)
        {
            laps++;
            comprover1 = false;
            comprover2 = false;
        }
        if (laps >= MaxLaps)
        {
            Contador.text = "Last Lap";
        }
        if (laps > MaxLaps)
        {
            MetaFinal.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meta"))
        {
            comprover1 = true;
        }
        if (other.gameObject.CompareTag("Meta2"))
        {
            comprover2 = true;
        }
        if (other.gameObject.CompareTag("FinalMeta"))
        {
            SceneManager.LoadScene("FinishScene");
        }
    }
}
