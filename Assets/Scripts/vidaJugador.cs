using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private bool invensible;
    [SerializeField] private barraDeVida barraDeVida;
    [SerializeField] private float tiempoInvencibilidad = 2f; // Duración de la invencibilidad en segundos
    public SpriteRenderer spriteRenderer;
    private Collider2D enemy;


    private void Start()
    {
        vida = maximoVida;
        barraDeVida.Instance.inicializarBarraDeVida(vida);
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GameObject.FindWithTag("Enemys").GetComponent<Collider2D>();
    }

    public void tomarDano(float dano)
    {
        if (!invensible){
            vida -= dano;
            barraDeVida.Instance.cambiarVidaActual(vida);
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
            invensible = true;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            Physics2D.IgnoreCollision(enemy, GetComponent<Collider2D>());
            StartCoroutine(TemporizadorInvencibilidad());
        }
    }
        
    private IEnumerator TemporizadorInvencibilidad()
    {
        yield return new WaitForSeconds(tiempoInvencibilidad);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        invensible = false;
    }

}
