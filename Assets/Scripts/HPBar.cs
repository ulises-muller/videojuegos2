using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public static HPBar Instance;
   
    private Slider slider;


    public void ChangeMaxHP(float MaxHP)
    {
       slider.maxValue = MaxHP;
    }


    public void ChangeCurrentHP(float HPAmount)
    {
        slider.value = HPAmount;
    }
   
    public void InitializeHPBar(float HPAmount)
    {
        slider = GetComponent<Slider>();
        ChangeMaxHP(HPAmount);
        ChangeCurrentHP(HPAmount);
    }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
