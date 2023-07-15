using DG.Tweening;
using Farm;
using UnityEngine;
using Utils.Event;

namespace Player
{
    public class HarvestController : MonoBehaviour
    {
        [SerializeField] private Transform VacuumPoint;
        [SerializeField] private GameEvent VacuumCrops;
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out FruitCollider fruit);
            if (fruit)
            {
                fruit.transform.parent = transform;
                fruit.transform.DOJump(VacuumPoint.position, 1.5f,1,.5f);
                fruit.transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
                {
                    Destroy(fruit.gameObject);
                    VacuumCrops.Raise();
                });
            }
        }
    }
}