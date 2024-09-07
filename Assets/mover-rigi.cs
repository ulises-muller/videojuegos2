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
  public SpriteRenderer spriteRenderer;
  private Animator animator;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }


  void Update()
  {
    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");
    moveInput = new Vector2(moveX, moveY).normalized;
    movimientoSprite();
  }


void FixedUpdate(){
    rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveInput);
}
  void movimientoSprite()
  {
    if (Input.GetAxis("Horizontal") > 0)
    {
        spriteRenderer.flipX = true;
    }
    if (Input.GetAxis("Horizontal") < 0)
    {
        spriteRenderer.flipX = false;
    }
    if (Input.GetAxis("Vertical") > 0 )
    {
        animator.SetBool("arriba", true);
    }
    if (Input.GetAxis("Vertical") < 0 )
    {
        animator.SetBool("arriba", false);
    }
  }
}
