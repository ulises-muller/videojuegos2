using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timeScript : MonoBehaviour
{
    private float seconds;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        seconds += Time.deltaTime;
        textMesh.text = "Time: " + seconds.ToString("0");
    }
}
