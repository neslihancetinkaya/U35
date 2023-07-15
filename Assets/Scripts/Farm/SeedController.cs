using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utils.RefValue;

namespace Farm
{
    public class SeedController : MonoBehaviour
    {
        [SerializeField] private GameObject Seed;
        [SerializeField] private GameObject Dirt;
        [SerializeField] private GameObject Plant;
        [SerializeField] private GameObject Fruit;
        [SerializeField] private Transform PlantPoint;
        [SerializeField] private Material SeedMaterial;
        [SerializeField] private float Duration;
        [SerializeField] private bool IsPlantClose;
        [SerializeField] private ParticleSystem PoofFX;
        [SerializeField] private IntRef PlantedCount;

        private float _nextTime;
        private float _dissolve;
        private bool _isFirst;

        private void OnEnable()
        {
            PlantedCount.Value++;
            DOVirtual.DelayedCall(Duration, () =>
            {
                PoofFX.Play();
                Plant.SetActive(true);
            });
            DOVirtual.DelayedCall(2 * Duration, () =>
            {
                PoofFX.Play();
                if (IsPlantClose)
                {
                    Plant.SetActive(false);
                }            
                GameObject go = Instantiate(Fruit);
                go.transform.localPosition = PlantPoint.position;
            });
        }

        
        void Update()
        {
            if (_dissolve < .8f)
            {
                _dissolve += .005f;
                SeedMaterial.SetFloat("_Dissolve", _dissolve);
            }
            else
            {
                if (!_isFirst)
                {
                    _isFirst = true;
                    Seed.SetActive(false);
                    Dirt.SetActive(true);
                    Dirt.transform.DOScale(Vector3.one * 2, .5f);
                }
            }
        }
       
    }
}