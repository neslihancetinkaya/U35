using UnityEngine;

namespace Player
{
    public class PlayerCollider : MonoBehaviour
    {
        public Transform SpawnPoint;
        [SerializeField] private GameObject VacuumFx;
        [SerializeField] private Transform VacuumPoint;

        public void SpawnParticle()
        {
            var go = Instantiate(VacuumFx);
            go.transform.position = VacuumPoint.position;
        }
    }
}