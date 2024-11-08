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
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        // El movimiento ya se gestiona cuando se dispara
    }

    public float GetDamage()
    {
        return damage;  // Método para obtener el daño del proyectil
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // No es necesario aplicar el daño aquí, ya que lo manejamos en ia_prueba
    }
}


