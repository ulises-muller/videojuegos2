using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private bool invensible;
    [SerializeField] private barraDeVida barraDeVida;
    [SerializeField] private float tiempoInvencibilidad = 2f; // Duración de la invencibilidad en segundos
    public SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.Instance.inicializarBarraDeVida(vida);
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Método para aplicar daño
    public void tomarDano(float dano)
    {
        if (!invensible)
        {
            vida -= dano;
            barraDeVida.Instance.cambiarVidaActual(vida);
            if (vida <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);  // Muestra la escena de game over
            }
            invensible = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f); // El jugador se vuelve semi-transparente
            playerCollider.enabled = false;  // Deshabilitar el collider mientras está invencible
            StartCoroutine(TemporizadorInvencibilidad());
        }
    }

    // Invencibilidad temporal después de recibir daño
    private IEnumerator TemporizadorInvencibilidad()
    {
        yield return new WaitForSeconds(tiempoInvencibilidad);
        spriteRenderer.color = new Color(1, 1, 1, 1);  // Vuelve a la normalidad
        invensible = false;
        playerCollider.enabled = true;  // Habilita el collider
    }
}

