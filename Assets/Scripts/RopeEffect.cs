using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RopeEffect : MonoBehaviour
{
    [SerializeField] private List<Transform> RopeParts;
    [Range(0, 1)] [SerializeField] private float duration = 0.05f;
    public bool IsAnim;

    void Update()
    {
        if (IsAnim)
        {
            var sequence = DOTween.Sequence();
            
            foreach (var ropePart in RopeParts)
            {
                sequence.Append(ropePart.transform.DOScale(new Vector3(1.5f, 1, 1.5f), duration));
                sequence.Append(ropePart.transform.DOScale(new Vector3(1, 1, 1), duration));
            }
            // Count increase here
            IsAnim = false;
        }
        
    }
}
