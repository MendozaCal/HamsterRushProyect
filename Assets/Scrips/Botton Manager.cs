using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonManager : MonoBehaviour
{
    public void JumpScene(int escena)
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
