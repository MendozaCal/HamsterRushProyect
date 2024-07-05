using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    public void JumpScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    IEnumerator DesactiveTime()
    {
        yield return new WaitForSeconds(5);
        Desplegable.SetActive(false);
    }
}
