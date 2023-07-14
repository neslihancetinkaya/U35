using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

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

        private float _nextTime;
        private float _dissolve;

        private void OnEnable()
        {
            DOVirtual.DelayedCall(Duration, () =>
            {
                PoofFX.Play();
                Dirt.SetActive(true);
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
            if (_dissolve < 1)
            {
                _dissolve += .005f;
                SeedMaterial.SetFloat("_Dissolve", _dissolve);
                //SeedMesh.material.SetFloat("_Dissolve", _dissolve);
            }
            else
            {
                Seed.SetActive(false);
            }
        }
       
    }
}