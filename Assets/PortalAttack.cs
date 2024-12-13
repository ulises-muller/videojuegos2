using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // El prefab del proyectil
    [SerializeField] private Transform player; // Referencia al jugador
    [SerializeField] private float fireRate = 1f; // Tiempo entre disparos
    [SerializeField] private float projectileSpeed = 5f; // Velocidad del proyectil
    [SerializeField] private float attackDuration = 10f; // Duración del ataque
    private float timeSinceLastFire;

    // Ajuste de posición de disparo
    [SerializeField] private float offsetY = 0.5f; // Desplazamiento en Y para la posición de disparo

    void Start()
    {
        timeSinceLastFire = fireRate; // Iniciar el tiempo de espera para disparar
        player = GameObject.FindGameObjectWithTag("Player").transform; // Obtener al jugador automáticamente
    }

    void Update()
    {
        timeSinceLastFire += Time.deltaTime; // Acumular el tiempo transcurrido

        if (timeSinceLastFire >= fireRate)
        {
            ShootProjectileAtPlayer();
            timeSinceLastFire = 0f; // Resetear el tiempo de disparo
        }
    }

    void ShootProjectileAtPlayer()
    {
        // Ajustar la posición de disparo (con un offset en Y)
        Vector3 spawnPosition = transform.position + new Vector3(0, offsetY, 0); // Ajuste de la posición en Y
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity); // Crear el proyectil

        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;

        // Aplicar velocidad al proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed; // Aplicar la velocidad en la dirección calculada
        }
    }
}

