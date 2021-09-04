using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Bool", menuName="Data Types/Bool")]
public class BoolVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string description;
#endif

    public bool value = true;


    public void Trigger()
    {
        value = !value;
    }

    public void SetTrue()
    {
        value = true;
    }

    public void SetFalse()
    {
        value = false;
    }
}
