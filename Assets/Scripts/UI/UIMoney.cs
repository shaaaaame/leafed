using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMoney : MonoBehaviour
{
    public Text text;
    public FloatReference money;

    void Start()
    {
        UIManager.instance.RegisterUIItem(this.gameObject);
    }

    void Update()
    {
        UpdateText("Money : " + money.value);
    }

    void UpdateText(string line)
    {
        text.text = line;
    }
}
