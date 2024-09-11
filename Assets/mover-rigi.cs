using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovementTD : MonoBehaviour
{
  public float speed = 3f;
  private Rigidbody2D rb;
  private Vector2 moveInput;
  private float moveY;
  private float moveX;
  public SpriteRenderer spriteRenderer;
  private Animator animator;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }


  void Update()
  {
    moveX = Input.GetAxis("Horizontal");
    moveY = Input.GetAxis("Vertical");
    moveInput = new Vector2(moveX, moveY).normalized;
  }
  void FixedUpdate()
  {
    movimientoPersonaje();
  }
  
  void MovimientoSprite()
  {
    if (moveX > 0)
    {
        spriteRenderer.flipX = true;
    }
    if (moveX < 0)
    {
        spriteRenderer.flipX = false;
    }
    if (moveY > 0 )
    {
        animator.SetBool("arriba", true);
    }
    if (moveY < 0 )
    {
        animator.SetBool("arriba", false);
    }
  }
  void movimientoPersonaje()
  {
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveInput);
    }
    MovimientoSprite();
  }
}