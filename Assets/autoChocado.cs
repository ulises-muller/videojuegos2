using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoChocado : MonoBehaviour { 

        void OnCollisionEnter(Collision collision)
    {
        // Verifica el nombre del objeto con el que colisiona
        if (collision.gameObject.CompareTag("autoChocado"))
        {
            Debug.Log("¡Colisión con objeto detectada!");
        }
    }
}


