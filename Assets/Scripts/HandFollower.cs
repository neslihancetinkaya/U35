using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollower : MonoBehaviour
{
    public Transform Hand;

    private void LateUpdate()
    {
        transform.position = Hand.position;
    }
}
