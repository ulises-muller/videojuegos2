using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 20f;  // Cantidad de daño que hace el proyectil
    private Rigidbody2D projectileRb;

    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f); // El proyectil se destruye después de 1 segundo para evitar que se quede en la escena
    }

    void Update()
    {
        // El movimiento ya se gestiona cuando se dispara
    }

    // Método para obtener el daño del proyectil
    public float GetDamage()
    {
        return damage;  // Método para obtener el daño del proyectil
    }

    // Método para detectar colisiones (Usando Trigger si se requiere)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el proyectil colide con el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<vidaJugador>().tomarDano(damage); // Aplica el daño al jugador
            Destroy(gameObject); // Destruye el proyectil después de causar daño
        }
        // Si el proyectil toca cualquier otro objeto que no sea el jugador, se destruye
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destruye el proyectil si toca un enemigo
        }
    }
}





