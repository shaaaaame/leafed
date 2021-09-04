//Credit to Ryan Hipple's Unite 2017 talk!

using System;

[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public FloatReference(float value)
    {
        useConstant = true;
        constantValue = value;
    }

    public float value
    {
        get
        {
            return useConstant ? constantValue : variable.value;
        }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.value;
    }
}
