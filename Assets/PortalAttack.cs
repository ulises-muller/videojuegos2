using UnityEngine;

public class PortalAttack : MonoBehaviour
{
    [Header("Prefab del proyectil")]
    [SerializeField] private GameObject projectileForPlayer;

    [Header("Configuraciones de ataque")]
    [SerializeField] private float fireRate = 1f; // Tiempo entre disparos
    [SerializeField] private float projectileSpeed = 5f; // Velocidad del proyectil

    private GameObject player;
    private float timeSinceLastFire;

    void Start()
    {
        timeSinceLastFire = fireRate;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire >= fireRate)
        {
            ShootProjectileAtPlayer();
            timeSinceLastFire = 0f;
        }
    }

    void ShootProjectileAtPlayer()
    {
        if (projectileForPlayer == null) return;

        
        Vector3 spawnPosition = transform.position;
        GameObject projectile = Instantiate(projectileForPlayer, spawnPosition, Quaternion.identity);

        Vector2 direction = (player.transform.position - transform.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }
}




