using DG.Tweening;
using Player;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

namespace Tutorial
{
    public class SpaceshipMission : MonoBehaviour
    {
        [SerializeField] private BoolRef Mission3;
        [SerializeField] private GameObject SeedModel;
        [SerializeField] private Transform Point;
        [SerializeField] private GameEvent VacuumEffect;

        private bool _isUsed;
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                if (!_isUsed)
                {
                    _isUsed = true;
                    DOVirtual.DelayedCall(1.5f, () =>
                    {
                        GiveSeeds(player);
                    });
                }
            }
        }

        private void GiveSeeds(PlayerCollider player)
        {
            Mission3.Value = true;

            for (int i = 0; i < 10; i++)
            {
                var go = Instantiate(SeedModel, player.transform);
                go.transform.position = Point.position;
                DOVirtual.DelayedCall(.5f * i, () =>
                {
                    go.transform.DOJump(player.SpawnPoint.position, 1.5f, 1, .5f).OnComplete(() =>
                    {
                        go.transform.DOScale(Vector3.zero, 1.5f);
                        VacuumEffect.Raise();
                    });
                });
                Destroy(go, 10f);
            }
        }
    }
}