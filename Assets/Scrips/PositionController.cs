using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PositionController : MonoBehaviour
{
    [SerializeField]float cont = 0;
    [SerializeField]int positionPlayer = 0;
    [SerializeField] TextMeshProUGUI text;

    [Header("-----Position-----")]
    public Transform[] Hamsters;
    private int currentControlpoint = 0;
    private void Update()
    {

        text.text = cont.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            currentControlpoint++;
        }
    }
    /*void calculateDistanceControlPoint()
    {
        if (Vector3.Distance(transform.position, Hamsters[].position) < 1)
        {

            if (currentControlpoint >= Hamsters.Length)
            {
                currentControlpoint = 0;
            }
        }
    }*/
}
