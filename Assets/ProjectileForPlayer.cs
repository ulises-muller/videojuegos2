using UnityEngine;

public class ProjectileForPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 5f; // Daño del proyectil
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f); // El proyectil se destruye después de 2 segundos
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el proyectil toca al jugador
        if (other.CompareTag("Player"))
        {
            // Si colisiona con el jugador, se aplica el daño
            other.GetComponent<vidaJugador>()?.tomarDano(damage);
            Destroy(gameObject); // Destruye el proyectil después de causar daño
        }
        // Si colide con otro enemigo, no hace nada
        else if (other.CompareTag("Enemy"))
        {
            
            Destroy(gameObject); // Destruye el proyectil si toca un enemigo
        }
    }
}
