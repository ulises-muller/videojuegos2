using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraDeVida : MonoBehaviour
{
    public static barraDeVida Instance;
    private Slider slider;
    
    /*private void Start()
    {
        slider = GetComponent<Slider>();
    }*/
    public void cambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        slider = GetComponent<Slider>();
        cambiarVidaMaxima(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
    }
}
