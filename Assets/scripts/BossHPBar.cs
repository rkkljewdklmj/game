using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHPBar : MonoBehaviour
{
    public Slider slider;

   
    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = 500f;
        slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}