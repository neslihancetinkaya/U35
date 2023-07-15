using System;
using UnityEngine;
using Utils.RefValue;

public class FloatValueSetter : MonoBehaviour
{
    [SerializeField] private FloatRef FloatVal;
    [SerializeField] private float FloatCount;

    private void Start()
    {
        FloatVal.Value = FloatCount;
    }
}