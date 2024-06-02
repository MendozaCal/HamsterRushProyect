using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject EventeSystem;
    public GameObject Sliders;
    private bool isPaused = false;
    public TextMeshPro TextMeshPro;
    public float timer = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        EventeSystem.SetActive(true);
        Sliders.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        EventeSystem.SetActive(false);
        Sliders.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
