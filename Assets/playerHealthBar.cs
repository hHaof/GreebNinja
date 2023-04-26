using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;

    public Image fill;
    // Start is called before the first frame update

    public void SetMaxHealthBar(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealthBar(int currentHealth)
    {
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
