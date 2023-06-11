using UnityEngine;

namespace Utils.RefValue
{
    public class TransformRef : MonoBehaviour
    {
        public Transform Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private Transform _value; 
    }
}