using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{
    public FloatReference currentHealth;
    public FloatReference maxHealth;
    public Slider slider;

    void Start()
    {
        UIManager.instance.RegisterUIItem(this.gameObject);
        slider.maxValue = maxHealth;
    }

    void Update()
    {
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        slider.value = currentHealth;
    }

}
