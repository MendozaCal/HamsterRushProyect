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
    public float cont = 1;
    public bool contControl;
    public int laps = 0;
    public int MaxLaps = 3;
    public bool comprover1 = false;
    public bool comprover2 = false;
    public GameObject MetaFinal;
    PlayerController playerController;
    NPCroute[] NPCroute;
    public string tagScene;
    [Header("-----Time-----")]
    public static float contTime;
    public TextMeshProUGUI contTimerFinal;
    public bool isTimerRunning = false;
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
        if (!contControl)
        {
            cont += Time.deltaTime * 0.5f;
        }
        float contadorRedondeado = Mathf.Round(cont);
        Contador.text = contadorRedondeado.ToString();
        if (cont >= 3)
        {
            Contador.text = $"Start";
            playerController.enabled = true;
            if (!isTimerRunning)
            {
                TimerController();
            }
            foreach (NPCroute npcRoute in NPCroute)
            {
                npcRoute.enabled = true;
            }
            if (cont >= 5)
            {
                Contador.text = $"Lap {laps}/{MaxLaps}";
                contControl = true;
            }
        }
        if (comprover1 == true && comprover2 == true)
        {
            laps++;
            comprover1 = false;
            comprover2 = false;
        }
        if (laps == MaxLaps)
        {
            Contador.text = "Last Lap";
        }
        else if (laps >= MaxLaps)
        {
            Contador.text = "Finish";
        }
        if (laps > MaxLaps)
        {
            MetaFinal.SetActive(true);
        }
    }
    void TimerController()
    {
        contTime += Time.deltaTime;
        contTimerFinal.text = FormatTime(contTime);
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
            isTimerRunning = true;
            SceneManager.LoadScene(tagScene);
        }
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}