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
        rb.transform.position = new Vector3(Random.Range(80,-80),Random.Range(80,-80), 0);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rocas"))
        {
            rb.transform.position = new Vector3(Random.Range(80, -80), Random.Range(80, -80), 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
