using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pj;
    public float speed = 2f;  // velocidad del enemigo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (pj != null)
        {

            Vector2 direction = (pj.position - transform.position).normalized; // direccion hacia el jugador


            rb.transform.position = (Vector2)transform.position + (direction * speed * Time.deltaTime); // mueve al enemigo hacia el jugador
        }
    }
}
