using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_ : MonoBehaviour
{
    private Transform pausa;
    void Start()
    {
        pausa = GameObject.Find("pausa").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoadSceneAsync("Scene2"));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pausa.position = new Vector3(transform.position.x, transform.position.y, pausa.position.z);
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            pausa.transform.position = new Vector3(0, -1000, 0);
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




