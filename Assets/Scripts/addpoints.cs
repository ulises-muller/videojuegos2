using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addpoints : MonoBehaviour
{
    public int points = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PointSytem.Instance.AddingPoints(points);
            Destroy(gameObject);
        }
    }
}
