using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoolReference
{
    public BoolVariable variable;

    public bool value
    {
        get
        {
            return variable.value;
        }
    }
}
