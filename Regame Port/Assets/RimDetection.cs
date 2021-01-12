using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimDetection : MonoBehaviour
{
    public AccuracyChecker accuracyChecker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("has hit rim");
            accuracyChecker.hasHitRim = true;
        }
    }
}
