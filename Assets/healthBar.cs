using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    
    public Slider slider;


    // Start is called before the first frame update

    public void SetMaxHealthBar(int maxHealth){
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
       
    }

    public void SetHealthBar(int currentHealth){
        slider.value = currentHealth;   

    
    }
}
