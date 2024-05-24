using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void JumpScene(int escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
