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
    [SerializeField] private GameObject parte1;
    [SerializeField] private GameObject parte2;
    [SerializeField] private GameObject parte3;
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
        ManejarOpciones();
    }
    void ManejarOpciones()
    {
        switch (partes)
        {
            case 1:
                Debug.Log("Opción 1 seleccionada");
                parte1.SetActive(true);
                break;
            case 2:
                Debug.Log("Opción 2 seleccionada");
                parte2.SetActive(true);
                break;
            case 3:
                Debug.Log("Opción 3 seleccionada");
                Debug.Log("Arma completa");
                SpawnBoss();
                parte3.SetActive(true);
                partes = 0;
                break;
            default:
                break;
        }
    }
    void SpawnBoss()
    {
        Instantiate(salidaPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
