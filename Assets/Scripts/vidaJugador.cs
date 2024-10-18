using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private barraDeVida barraDeVida;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.Instance.inicializarBarraDeVida(vida);
    }

    public void tomarDano(float dano)
    {
        vida -= dano;
        barraDeVida.Instance.cambiarVidaActual(vida);
        /*if (vida <= 0)
        {
            Destroy(gameObject);
        }*/
    }

}
