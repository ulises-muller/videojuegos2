using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawndeenemigos : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigoPrefab; // Prefab del enemigo
    [SerializeField] private Transform jugador;   // Referencia al objeto del jugador
    [SerializeField] private float intervaloDeSpawn = 3f; // Intervalo de tiempo entre spawns
    [SerializeField] private float distanciaDeSpawn = 5f; // Distancia desde el jugador donde spawnearán los enemigos

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform; // Buscar el objeto del jugador
        if (jugador == null) { 
            Debug.LogError("No se encontró el objeto del jugador."); 
            return; 
        }
        StartCoroutine(SpawnEnemigos()); // Iniciar la corrutina para spawnear enemigos
    }

    private IEnumerator SpawnEnemigos()
    {
        while (true)
        {

            if (jugador == null) { yield break; }

            for (int i = 0; i < 3; i++)
            {
                Vector3 spawnPosition = jugador.position + (Vector3)(Random.insideUnitCircle.normalized * distanciaDeSpawn);
                Instantiate(enemigoPrefab[i], spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(intervaloDeSpawn); // Esperar 3 segundos antes de spawnear de nuevo
        }
    }
}
