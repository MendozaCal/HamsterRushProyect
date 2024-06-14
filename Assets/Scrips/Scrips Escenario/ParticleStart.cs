using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject humo1;
    public GameObject humo2;
    public GameObject humo3;
    public GameObject humo4;
    public GameObject humo5;
    public GameObject humo6;

    void Update()
    {
        if (text.text == "Start")
        {
            humo1.SetActive(false);
            humo2.SetActive(false);
            humo3.SetActive(true);
            humo4.SetActive(true);
        }
        if (text.text == "Last Lap")
        {
            humo3.SetActive(false);
            humo4.SetActive(false);
            humo5.SetActive(true);
            humo6.SetActive(true);
        }
    }
}
