using System;

[Serializable]
public class IntReference
{
    public bool UseConstant = true;
    
    public float Constant;
    
    public IntVariable Variable;

    public float Value => UseConstant ? Constant : Variable.Value;
}
