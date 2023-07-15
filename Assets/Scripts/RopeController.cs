using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

public class RopeController : MonoBehaviour
{
    [SerializeField] private List<Transform> RopeParts;
    [SerializeField] private List<Transform> ReverseRopeParts;
    [SerializeField] private FloatRef Health;
    [SerializeField] private GameEvent ThrowSeed;
    [Range(0, 1)] [SerializeField] private float duration = 0.05f;
    

    public void PlayVacuumEffect()
    {
        VacuumEffect();

        if (Health.Value <= 97)
        {
            Health.Value += 3;
        }
        else if (Health.Value > 97)
        {
            Health.Value = 100;
        }

    }

    public void VacuumEffect()
    {
        var sequence = DOTween.Sequence();
            
        foreach (var ropePart in RopeParts)
        {
            sequence.Append(ropePart.transform.DOScale(new Vector3(1.5f, 1, 1.5f), duration));
            sequence.Append(ropePart.transform.DOScale(new Vector3(1, 1, 1), duration));
        }
    }
    
    public void PlayThrowEffect()
    {
        ThrowEffect();
        ThrowSeed.Raise();
    }

    public void ThrowEffect()
    {
        var sequence = DOTween.Sequence();
        foreach (var ropePart in ReverseRopeParts)
        {
            sequence.Append(ropePart.transform.DOScale(new Vector3(1.5f, 1, 1.5f), duration));
            sequence.Append(ropePart.transform.DOScale(new Vector3(1, 1, 1), duration));
        }
    }
}
