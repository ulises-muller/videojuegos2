using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // tart is called before the first frame update
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererEspalda;
    public Transform pjatras;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){  
            rb.transform.position = new Vector3(transform.position.x,transform.position.y + 10f* Time.deltaTime,0 );
            pjatras.position =  transform.position;
        }
        
        if (Input.GetKeyDown(KeyCode.W)){
            spriteRendererEspalda.sortingOrder = 0;
            spriteRenderer.sortingOrder = -14;
        }
        if (Input.GetKey(KeyCode.S)){
            rb.transform.position = new Vector3(transform.position.x,transform.position.y - 10f * Time.deltaTime,0);
            pjatras.position =  transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S)){
            spriteRendererEspalda.sortingOrder = -14;
            spriteRenderer.sortingOrder = 0;
        }
        if(Input.GetKey(KeyCode.A)){
            rb.transform.position = new Vector3(transform.position.x - 10f * Time.deltaTime,transform.position.y ,0);
            spriteRenderer.flipX = false;
            pjatras.position =  transform.position;
            spriteRendererEspalda.flipX = false;
        }
        if (Input.GetKey(KeyCode.D)){
            rb.transform.position = new Vector3(transform.position.x + 10f * Time.deltaTime,transform.position.y,0);
            spriteRenderer.flipX = true;
            pjatras.position =  transform.position;
            spriteRendererEspalda.flipX = true;
        }        
    }
}
