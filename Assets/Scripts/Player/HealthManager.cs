using UnityEngine;
using Utils.RefValue;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private FloatRef Health;
        [SerializeField] private float DecreaseAmount = 0.1f;
        [SerializeField] private float RepeatTime;

        private float _nextTime;
        void Update()
        {
            if (Time.time > _nextTime)
            {
                Health.Value -= DecreaseAmount;
                _nextTime = Time.time + RepeatTime;
            }
        }
    }
}
