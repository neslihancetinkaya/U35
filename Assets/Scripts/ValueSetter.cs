using System;
using UnityEngine;
using Utils.RefValue;

namespace DefaultNamespace
{
    public class ValueSetter : MonoBehaviour
    {
        [SerializeField] private FloatRef Val;
        [SerializeField] private float Count;

        private void Start()
        {
            Val.Value = Count;
        }
    }
}