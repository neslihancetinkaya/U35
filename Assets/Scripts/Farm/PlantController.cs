using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utils.Event;

namespace Player
{
    public class PlantController : MonoBehaviour
    {
        public Transform SeedPoint;
        public GameEvent SeedPlant;
        [SerializeField] private List<GameObject> Seeds;

        private bool _isUsed;
        private void OnTriggerEnter(Collider other)
        {
            if (_isUsed)
                return;
            
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                SeedPlant.Raise();
                GameObject seed = Instantiate(Seeds[Random.Range(0, Seeds.Count)], SeedPoint);
                seed.transform.position = player.SpawnPoint.position;
                seed.transform.DOLocalJump(Vector3.zero, 3,1,.5f);
                _isUsed = true;
            }
        }
    }
}