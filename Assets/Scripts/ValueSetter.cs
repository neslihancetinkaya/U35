using System;
using UnityEngine;
using Utils.RefValue;

namespace DefaultNamespace
{
    public class ValueSetter : MonoBehaviour
    {
        [SerializeField] private bool IsFloat;
        [SerializeField] private bool IsInt;
        [SerializeField] private FloatRef FloatVal;
        [SerializeField] private float FloatCount;
        [SerializeField] private IntRef IntVal;
        [SerializeField] private int IntCount;

        private void Start()
        {
            if (IsFloat)
            {
                FloatVal.Value = FloatCount;
            }

            if (IsInt)
            {
                IntVal.Value = IntCount;
            }
            
        }
    }
}