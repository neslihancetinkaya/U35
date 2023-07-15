using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.RefValue;

namespace Farm
{
    public class ResetBools : MonoBehaviour
    {
        [SerializeField] private List<BoolRef> Bools;

        private void Start()
        {
            foreach (var val in Bools)
            {
                val.Value = false;
            }
        }
    }
}