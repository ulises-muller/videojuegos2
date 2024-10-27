using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
       public AudioSource audioSource;
    private bool isPaused = false; // Booleano para pausar y reanudar con un botón
    void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        audioSource.Pause();
        isPaused = true;
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        audioSource.Play();
        isPaused = false;
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}

