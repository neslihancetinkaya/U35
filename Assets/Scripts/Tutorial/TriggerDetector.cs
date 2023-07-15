using Player;
using UnityEngine;
using Utils.RefValue;

namespace Tutorial
{
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField] private BoolRef MissionBool;

        private bool _isUsed;
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                if (!_isUsed)
                {
                    _isUsed = true;
                    MissionBool.Value = true;
                }
            }
        }
    }
}