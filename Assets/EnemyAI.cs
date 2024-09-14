using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pj;
    public float speed = 2f;  // velocidad del enemigo

    void Update()
    {

        if (pj != null)
        {

            Vector2 direction = (pj.position - transform.position).normalized; // direccion hacia el jugador


            transform.position = (Vector2)transform.position + (direction * speed * Time.deltaTime); // mueve al enemigo hacia el jugador
        }
    }
}
