using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BottonManager : MonoBehaviour
{
    AudioSource audioSource;
    public Image image;
    public Sprite sprite1;
    public Sprite sprite2;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject camera = Camera.main.gameObject;
        audioSource = camera.GetComponent<AudioSource>();
    }
    public void JumpScene(string escena)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
    }
    public void OfMusic()
    {
        if (audioSource != null )
        {
            audioSource.mute = !audioSource.mute;
            if (audioSource.mute)
            {
                image.sprite = sprite2;
            }
            else
            {
                image.sprite = sprite1;
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
