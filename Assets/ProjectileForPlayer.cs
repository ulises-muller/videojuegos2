using UnityEngine;

public class ProjectileForPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 20f;  // Cantidad de daño que hace el proyectil
    private Rigidbody2D projectileRb;

    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f); // El proyectil se destruye después de 1 segundo para evitar que se quede en la escena
    }

    // Método para detectar colisiones
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verifica si el proyectil colisiona con el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Aplica daño al jugador
            var playerHealth = other.gameObject.GetComponent<vidaJugador>();
            if (playerHealth != null)
            {
                playerHealth.tomarDano(damage);
            }
            Destroy(gameObject); // Destruye el proyectil después de causar daño
        }
    }
}




