using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private vidaJugador vidaJugador;

    private void Start(){
        vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<vidaJugador>();
        vidaJugador.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e) {
        menuGameOver.SetActive(true);
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        #if UNITY_EDITOR  
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
