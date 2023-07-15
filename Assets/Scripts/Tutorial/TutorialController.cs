using System;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

namespace Tutorial
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField] private IntRef PlantedCount;
        [SerializeField] private IntRef HarvestedCount;
        [SerializeField] private BoolRef Mission4;
        [SerializeField] private BoolRef Mission5;
        [SerializeField] private GameEvent OpenTeleport;

        private bool _isUsed;
        private void Update()
        {
            if (PlantedCount.Value == 15)
            {
                Mission4.Value = true;
            }
            if (HarvestedCount.Value == 15)
            {
                Mission5.Value = true;
            }

            if (Mission5.Value)
            {
                if (!_isUsed)
                {
                    _isUsed = true;
                    OpenTeleport.Raise();
                }
            }
        }
    }
}