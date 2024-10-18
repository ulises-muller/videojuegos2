using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointSystem : MonoBehaviour
{
    public static pointSystem Instance;
    public TextMeshProUGUI textPoints;
    private int points = 20;
    public void addPoints(int quantity)
    {
        points += quantity;
        updateUi();
    }

    public void subPoints(int quantity)
    {
        points -= quantity;
        updateUi();
    }

    public void updateUi()
    {
        if (points < 0) {
            points = 0;
        }

        textPoints.text = "Points: " + points.ToString();
    }

    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
