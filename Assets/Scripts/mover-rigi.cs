using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTD : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float moveY;
    private float moveX;
    private SpriteRenderer spriteRenderer;
    public bool facingRight = true; // Dirección del personaje

    [Header("Shooting Settings")]
    [SerializeField] private GameObject projectilePrefab;  // Prefab del proyectil
    [SerializeField] private float projectileSpeed = 10f;  // Velocidad del proyectil

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        // Disparo al presionar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            ShootTowardsMouse();
        }
    }

    void FixedUpdate()
    {
        movimientoPersonaje();
    }

    void MovimientoSprite()
    {
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            facingRight = true;
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            facingRight = false;
        }
    }

    void movimientoPersonaje()
    {
        if (moveInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * moveInput);
        }
        MovimientoSprite();
    }

    void ShootTowardsMouse()
    {
        // Obtener la posición del mouse en el mundo
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección desde el jugador hacia el mouse
        Vector2 shootingDirection = (mousePosition - (Vector2)transform.position).normalized;

        // Instanciar el proyectil en la posición del jugador
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Asignar velocidad al proyectil en la dirección del mouse
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        rbProjectile.velocity = shootingDirection * projectileSpeed;
    }
}
