using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddPoints : MonoBehaviour
{
    public int pointsToAdd;


    void OnDestroy()
    {
        pointSystem.Instance.addPoints(pointsToAdd);
    }
}
