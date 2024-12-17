using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class pointSystem : MonoBehaviour
{
    public static pointSystem Instance;
    public TextMeshProUGUI textPoints;
    private int points = 0;
    private int curarse = 100;
    private vidaJugador playerVida;

    private void Start() {
        playerVida = FindObjectOfType<vidaJugador>();
    }
    public void addPoints(int quantity)
    {
        points += quantity;
        updateUi();

        if (points >= curarse) {
            curarse += 100;
            playerVida.curarVida(1);
        }
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
