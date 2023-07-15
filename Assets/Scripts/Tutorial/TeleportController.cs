using System;
using Player;
using UnityEngine;
using Utils.Event;

namespace Tutorial
{
    public class TeleportController : MonoBehaviour
    {
        [SerializeField] private GameEvent Entered;
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                Entered.Raise();
            }
        }
    }
}