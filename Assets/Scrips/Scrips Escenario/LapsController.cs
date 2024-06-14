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
    int laps = 1;
    public int MaxLaps = 3;
    public bool comprover1 = false;
    public bool comprover2 = false;
    public GameObject MetaFinal;
    PlayerController playerController;
    NPCroute NPCroute;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.enabled = false;
        NPCroute = FindObjectOfType<NPCroute>();
        NPCroute.enabled = false;
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
            NPCroute.enabled = true;
        }
    }

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
