using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonManager : MonoBehaviour
{
    AudioSource audioSource;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject camera = Camera.main.gameObject;
        audioSource = camera.GetComponent<AudioSource>();
    }
    public void JumpScene(string escena)
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
    }
    public void OfMusic()
    {
        if (audioSource != null )
        {
            audioSource.mute = !audioSource.mute;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
