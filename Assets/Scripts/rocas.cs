using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocas : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector3(Random.Range(-160,155),Random.Range(75,-56), 0);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rocas") || collision.gameObject.CompareTag("Tronquitos") || collision.gameObject.CompareTag("auto") || collision.gameObject.CompareTag("arboles"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
