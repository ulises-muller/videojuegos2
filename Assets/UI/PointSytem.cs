using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointSytem : MonoBehaviour
{
    public static PointSytem Instance;
    public TextMeshProUGUI textPoints;
    private int points = 0;


    public void AddingPoints(int quantity)
    {
        points += quantity;
        UpdateUI();
    }


    public void SubstractingPoints(int quantity)
    {
        points -= quantity;
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (points < 0)
        {
            points = 0;
        }


        textPoints.text = "Points: " + points.ToString();
    }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
