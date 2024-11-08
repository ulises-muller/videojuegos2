using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class partes_armas : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;  // Prefab del jefe
    [SerializeField] private GameObject salidaPrefab;  // Prefab de la salida
    [SerializeField] private Transform spawnPoint;   // Punto de spawn del jefe
    [SerializeField] private Transform spawnPointSalida;
    private int partes = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arma")
        {
            Destroy(collision.gameObject);
            partes++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (partes == 3)
        {
            Debug.Log("Arma completa");
            SpawnBoss();
            partes = 0;
        }
    }
    void SpawnBoss()
    {
        Instantiate(salidaPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
