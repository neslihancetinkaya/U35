using UnityEngine;

namespace Utils.RefValue
{
    public class FloatRef : MonoBehaviour
    {
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private float _value; 
    }
}