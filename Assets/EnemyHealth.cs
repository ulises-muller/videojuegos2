using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Salud del enemigo

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Método para manejar la muerte del enemigo
    void Die()
    {
        // Aquí puedes agregar lo que deba suceder cuando el enemigo muere (por ejemplo, destruirlo)
        Destroy(gameObject);
    }
}
