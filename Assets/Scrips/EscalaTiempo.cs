using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscalaTiempo : MonoBehaviour
{
    public TextMeshProUGUI Time1;
    public TextMeshProUGUI Time2;
    public TextMeshProUGUI Time3;
    public TextMeshProUGUI Time4;
    public TextMeshProUGUI Time5;
    public TextMeshProUGUI Time6;

    public GameObject Imagenes1;
    public GameObject Imagenes2;
    public GameObject Imagenes3;
    public GameObject Imagenes4;

    List<float> values = new List<float>();
    LapsController timePlayer;
    public float first = 110.75f;
    public float second = 124.22f;
    public float third = 141.831f;
    public float forthy = 143.564f;
    public float fivethy = 160.015f;
    void Start()
    {
        timePlayer = GetComponent<LapsController>();
        values.Add(first);
        values.Add(second);
        values.Add(third);
        values.Add(forthy);
        values.Add(fivethy);

        Time1.text = FormatTime(first);
        Time2.text = FormatTime(second);
        Time3.text = FormatTime(third);
        Time4.text = FormatTime(forthy);
        Time5.text = FormatTime(fivethy);

        UpdateTimeText();

    }
    void Update()
    {
        float cont = LapsController.contTime;

        if (!values.Contains(cont))
        {
            values.Add(cont);
            values.Sort();
            UpdateTimeText();
        }
        UpdateImages(cont);

    }
    private void UpdateTimeText()
    {
        if (values.Count > 0)
            Time1.text = FormatTime(values[0]);
        if (values.Count > 1)
            Time2.text = FormatTime(values[1]);
        if (values.Count > 2)
            Time3.text = FormatTime(values[2]);
        if (values.Count > 3)
            Time4.text = FormatTime(values[3]);
        if (values.Count > 4)
            Time5.text = FormatTime(values[4]);
        if (values.Count > 5)
            Time6.text = FormatTime(values[5]);
    }
    private void UpdateImages(float cont)
    {
        if (Mathf.Approximately(cont, values[0]))
        {
            ActivateImage(Imagenes1);
        }
        else if (Mathf.Approximately(cont, values[1]))
        {
            ActivateImage(Imagenes2);
        }
        else if (Mathf.Approximately(cont, values[2]))
        {
            ActivateImage(Imagenes3);
        }
        else
        {
            ActivateImage(Imagenes4);
        }
    }
    private void ActivateImage(GameObject imageToActivate)
    {
        Imagenes1.SetActive(imageToActivate == Imagenes1);
        Imagenes2.SetActive(imageToActivate == Imagenes2);
        Imagenes3.SetActive(imageToActivate == Imagenes3);
        Imagenes4.SetActive(imageToActivate == Imagenes4);
    }
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

}