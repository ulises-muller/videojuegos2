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
  private SpriteRenderer spriteRenderer;
  private Animator animator;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
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
  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("rocas"))
    {
        Physics2D.IgnoreCollision(coll.collider, GetComponent<Collider2D>());
    }
  }
  void movimientoPersonaje()
  {
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveInput);
    }
    MovimientoSprite();
  }
}