using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tronquito : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector3(Random.Range(-160, 155), Random.Range(75, -56), 0);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boxarbol") || collision.gameObject.CompareTag("arboles"))
        {
            rb.transform.position = new Vector3(Random.Range(-160, 155), Random.Range(75, -56), 0);
        }
    }
    // Update is called once per f  rame
    void Update()
    {

    }
}
