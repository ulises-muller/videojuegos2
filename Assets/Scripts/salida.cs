using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar el namespace para la gestión de escenas

public class salida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AvanzarNivel();
        }
    }

    void AvanzarNivel()
    {
        int siguienteEscenaIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscenaIndex);
        }
        else
        {
            Debug.Log("No hay más niveles para cargar.");
        }
    }
}
