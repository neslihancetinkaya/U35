using System;
using UnityEngine;
using Utils.RefValue;

public class IntValueSetter : MonoBehaviour
{
    [SerializeField] private IntRef IntVal;
    [SerializeField] private int IntCount;

    private void Start()
    {
        IntVal.Value = IntCount;
    }
}