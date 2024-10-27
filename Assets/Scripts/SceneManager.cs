using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_ : MonoBehaviour
{

    public AudioSource audioSource;
    void Start()
    {    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoadSceneAsync("Scene2"));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.Pause();
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Play();
            ResumeGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            // Here you can communicate the progress to the player
            // e.g., a loading bar
            yield return null;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}




