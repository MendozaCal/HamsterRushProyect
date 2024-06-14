using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void JumpScene(string escena)
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
        //AudioListener.pause = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
