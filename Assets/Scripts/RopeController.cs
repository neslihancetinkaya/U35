using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [SerializeField] private List<Transform> RopeParts;
    [Range(0, 1)] [SerializeField] private float duration = 0.05f;
    public bool IsAnim;
    
    private List<Transform> list;

    private void Start()
    {
        list = RopeParts;
        list.Reverse();
    }

    void Update()
    {
        if (IsAnim)
        {
            PlayVacuumEffect();
            IsAnim = false;
        }
    }

    public void PlayVacuumEffect()
    {
        var sequence = DOTween.Sequence();
            
        foreach (var ropePart in RopeParts)
        {
            sequence.Append(ropePart.transform.DOScale(new Vector3(1.5f, 1, 1.5f), duration));
            sequence.Append(ropePart.transform.DOScale(new Vector3(1, 1, 1), duration));
        }
        // Count increase here
    }
    
    public void PlayThrowEffect()
    {
        var sequence = DOTween.Sequence();
        foreach (var ropePart in list)
        {
            sequence.Append(ropePart.transform.DOScale(new Vector3(1.5f, 1, 1.5f), duration));
            sequence.Append(ropePart.transform.DOScale(new Vector3(1, 1, 1), duration));
        }
        // ThrowSeeds
    }
}
