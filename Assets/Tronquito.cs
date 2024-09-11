using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tronquito : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(80,-80),Random.Range(80,-80), 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Random.Range(0,2) == 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(Random.Range(80,-80),Random.Range(80,-80), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
