using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapsControllerTutorial : MonoBehaviour
{
    [Header("-----Controller Text Tutorial-----")]
    public GameObject HealthSlider;
    public GameObject NitroSlider;
    public GameObject Tutorial;
    public GameObject TutorialMessage;
    public GameObject TutorialMessage2;
    public GameObject TutorialMessageRamps;
    public GameObject TutorialMessageNitro;
    public GameObject TutorialMessagePits;
    public GameObject TutorialMessageRace;
    bool isActiveRamps = false;
    bool isActiveNitro = false;
    bool isActivePits = false;
    bool isActiveRace = false;
    [Header("-----Cont Vueltas-----")]
    public TextMeshPro Contador;
    float cont = 1;
    int laps = 1;
    public int MaxLaps = 3;
    public bool comprover1 = false;
    public bool comprover2 = false;
    public GameObject MetaFinal;
    PlayerController playerController;
    bool isActive = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerController.enabled = false;
        StartCoroutine(TutorialController1());
    }
    private void Update()
    {
        if (isActive == true)
        {
            StartController();
        }
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
        }
        if (comprover1 == true && comprover2 == true && laps < MaxLaps)
        {
            comprover1 = false;
            comprover2 = false;
        }
        if (laps == MaxLaps)
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
            Contador.text = $"Lap {laps}/{MaxLaps}";
        }
        if (other.gameObject.CompareTag("Meta2"))
        {
            comprover2 = true;
            laps++;
        }
        
        if (Contador.text == "Last Lap" && other.gameObject.CompareTag("FinalMeta"))
        {
            SceneManager.LoadScene("FinishScene");
        }
        if (other.gameObject.CompareTag("RampsTutorial") && isActiveRamps == false)
        {
            StartCoroutine(TutorialControllerRamps());
        }
        if (other.gameObject.CompareTag("NitroTutorial") && isActiveNitro == false)
        {
            StartCoroutine(TutorialControllerNitro());
        }
        if (other.gameObject.CompareTag("PitsTutorial") && isActivePits == false)
        {
            StartCoroutine(TutorialControllerPits());
        }
        if (other.gameObject.CompareTag("RaceTutorial") && isActiveRace == false)
        {
            StartCoroutine(TutorialControllerRace());
        }
    }
    IEnumerator TutorialController1()
    {
        yield return new WaitForSeconds(1);
        Tutorial.SetActive(true);
        TutorialMessage.SetActive(true);
        yield return new WaitForSeconds(5);
        TutorialMessage.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        TutorialMessage2.SetActive(true);
        yield return new WaitForSeconds(5);
        TutorialMessage2.SetActive(false);
        Tutorial.SetActive(false);
        isActive = true;
    }
    IEnumerator TutorialControllerRamps()
    {
        HealthSlider.SetActive(true);
        yield return new WaitForSeconds(1);
        Tutorial.SetActive(true);
        TutorialMessageRamps.SetActive(true);
        yield return new WaitForSeconds(4);
        TutorialMessageRamps.SetActive(false);
        Tutorial.SetActive(false);
        playerController.maxSpeed = playerController.incialSpeed;
        isActiveRamps = true;
    }
    IEnumerator TutorialControllerNitro()
    {
        NitroSlider.SetActive(true);
        yield return new WaitForSeconds(1);
        Tutorial.SetActive(true);
        TutorialMessageNitro.SetActive(true);
        yield return new WaitForSeconds(5);
        TutorialMessageNitro.SetActive(false);
        Tutorial.SetActive(false);
        playerController.isNitro = true;
        playerController.maxSpeed = playerController.incialSpeed;
        isActiveNitro = true;
    }
    IEnumerator TutorialControllerPits()
    {
        yield return new WaitForSeconds(1);
        Tutorial.SetActive(true);
        TutorialMessagePits.SetActive(true);
        yield return new WaitForSeconds(5);
        TutorialMessagePits.SetActive(false);
        Tutorial.SetActive(false);
        playerController.maxSpeed = playerController.incialSpeed;
        isActivePits = true;
    }
    IEnumerator TutorialControllerRace()
    {
        yield return new WaitForSeconds(1);
        Tutorial.SetActive(true);
        TutorialMessageRace.SetActive(true);
        yield return new WaitForSeconds(5);
        TutorialMessageRace.SetActive(false);
        Tutorial.SetActive(false);
        playerController.maxSpeed = playerController.incialSpeed;
        isActiveRace = true;
    }
}
