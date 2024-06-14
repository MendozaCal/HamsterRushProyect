using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonReaction : MonoBehaviour
{
    public GameObject Desplegable;
    public GameObject Desplegable2;

    public void OnPointerEnter()
    {
        Desplegable.SetActive(true);
        Desplegable2.SetActive(false);
    }

    public void OnPointerExit()
    {
        StartCoroutine(DesactiveTime());
    }

    IEnumerator DesactiveTime()
    {
        yield return new WaitForSeconds(5);
        Desplegable.SetActive(false);
    }
}
