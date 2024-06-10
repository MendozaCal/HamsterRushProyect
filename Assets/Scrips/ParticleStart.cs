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

    void Update()
    {
        if (text.text == "Start")
        {
            humo1.SetActive(false);
            humo2.SetActive(false);
            humo3.SetActive(true);
            humo4.SetActive(true);
        }
    }
}
