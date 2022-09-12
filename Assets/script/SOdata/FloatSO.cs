using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/FloatSO")]
public class FloatSO : ScriptableObject
{
   [SerializeField]
   private float _value;

    public float Value
    {
        get { return Value; }
        set { _value = value; }
    }
}
