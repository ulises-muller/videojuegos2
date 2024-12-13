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

    [Header("Special Attack Settings")]
    [SerializeField] private float specialAttackRange = 5f; // Rango del ataque especial
    [SerializeField] private float specialAttackCooldown = 10f; // Tiempo entre ataques especiales
    [SerializeField] private int specialAttackDamage = 3; // Daño del ataque especial
    private float specialAttackTimer; // Temporizador para el ataque especial

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        specialAttackTimer = specialAttackCooldown; // Iniciar el temporizador
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        // Movimiento hacia el jugador si está dentro del rango pero fuera del alcance de "detenerse"
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

        // Manejo del temporizador y ejecución del ataque especial
        HandleSpecialAttack(distance);
    }

    private void HandleSpecialAttack(float distance)
    {
        specialAttackTimer -= Time.deltaTime;

        if (specialAttackTimer <= 0 && distance <= specialAttackRange)
        {
            // Ejecutar el ataque especial
            Debug.Log("El jefe realiza un ataque especial!");

            // Si el jugador está en rango, aplicamos daño
            if (distance <= specialAttackRange)
            {
                player.GetComponent<vidaJugador>().tomarDano(specialAttackDamage);
            }

            // Reiniciar el temporizador
            specialAttackTimer = specialAttackCooldown;
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

