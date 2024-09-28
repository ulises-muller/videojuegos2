using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    private float moveX;
    private Animator animator;
    private float moveY;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

  void MovimientoSprite()
  {
    if (moveX > 0)
    {
        animator.SetBool("abajo", false);
        animator.SetBool("decostado", true);
    }
    if (moveX < 0)
    {
        animator.SetBool("abajo", false);
        animator.SetBool("decostado", true);
    }
    if (moveY > 0 )
    {
        animator.SetBool("abajo", false);
        animator.SetBool("decostado", false);
        animator.SetBool("arriba", true);
    }
    if (moveY < 0 )
    {
        animator.SetBool("decostado", false);
        animator.SetBool("arriba", false);
        animator.SetBool("abajo", true);
    }
  }
    // Update is called once per frame
    void FixedUpdate()
    {
        MovimientoSprite();
        animator.SetFloat("floatX", Mathf.Abs(moveX));
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetFloat("floatY", Mathf.Abs(moveY));
        }
        
    }
}
