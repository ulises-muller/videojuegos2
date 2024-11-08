using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ia_prueba : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private float stopDistance;
    [SerializeField] private float returnDistance;
    private bool flee = false;

    [Header("Enemy Health")]
    public float health = 100f;  // Salud del enemigo

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > _distance || distance <= stopDistance) return;

        if (!flee)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            if (distance > returnDistance) flee = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * chaseSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Si el enemigo colisiona con el jugador, empieza a huir
        if (other.gameObject.CompareTag("Player"))
        {
            flee = true;
        }

        // Si el enemigo colisiona con un proyectil, recibe daño
        if (other.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.GetDamage());  // Llamamos al método TakeDamage del enemigo
                Destroy(other.gameObject);  // Destruimos el proyectil después de colisionar
            }
        }
    }

    // Método para aplicar daño al enemigo
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
        // Aquí puedes agregar lo que deba suceder cuando el enemigo muere
        Destroy(gameObject);
    }
}

