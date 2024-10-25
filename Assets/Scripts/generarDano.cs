using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarDano : MonoBehaviour
{
    public object player;
    private void Start()
    {
       player = GameObject.Find("Player");
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<vidaJugador>().tomarDano(1);
        }
        
    }

}
