using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererEspalda;
    public Transform pjatras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){  
            transform.position = new Vector3(transform.position.x,transform.position.y + 10f* Time.deltaTime,0 );
            pjatras.position =  transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W)){
            spriteRendererEspalda.sortingOrder = 0;
            spriteRenderer.sortingOrder = -14;
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position = new Vector3(transform.position.x,transform.position.y - 10f * Time.deltaTime,0);
            pjatras.position =  transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S)){
            spriteRendererEspalda.sortingOrder = -14;
            spriteRenderer.sortingOrder = 0;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = new Vector3(transform.position.x - 10f * Time.deltaTime,transform.position.y ,0);
            spriteRenderer.flipX = false;
            pjatras.position =  transform.position;
            spriteRendererEspalda.flipX = false;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position = new Vector3(transform.position.x + 10f * Time.deltaTime,transform.position.y,0);
            spriteRenderer.flipX = true;
            pjatras.position =  transform.position;
            spriteRendererEspalda.flipX = true;
        }        
    }
}
