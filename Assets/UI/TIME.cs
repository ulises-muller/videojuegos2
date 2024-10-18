
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
        textMesh.text = "tIME : " + seconds.ToString("0");
    }
}
