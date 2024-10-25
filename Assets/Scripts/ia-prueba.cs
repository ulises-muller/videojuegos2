using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ia_prueba : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private float stopDistance;
    [SerializeField] private float returnDistance;
    private bool flee = false;


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > _distance || distance <= stopDistance) return;


        if (!flee)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            if (distance > returnDistance) flee = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * chaseSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            flee = true;
        }
            if (other.gameObject.CompareTag("rocas") || other.gameObject.CompareTag("boxarbol"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
