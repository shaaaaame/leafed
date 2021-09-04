//Credit to Ryan Hipple's Unite 2017 talk!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Float", menuName="Data Types/Float")]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string description;
#endif

    public float value;

    public void SetValue(float val)
    {
        value = val;
    }
    
    public void SetValue(FloatVariable val)
    {
        value = val.value;
    }

    public void ApplyChange(float amount)
    {
        value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        value += amount.value;
    }
}
