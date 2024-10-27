using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;

public class ScriptMenu : MonoBehaviour

{
    void Start()
    {
    }
    public void primerNivel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
