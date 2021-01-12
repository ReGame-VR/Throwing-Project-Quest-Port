using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;

public class ObstacleCollisionDetection : MonoBehaviour
{
    private AccuracyChecker accuracyChecker; 
    
    // Start is called before the first frame update
    void Start()
    {
        accuracyChecker = FindObjectOfType<AccuracyChecker>();
        
        if(!accuracyChecker)
            Debug.Log("Could not find accuracy checker.");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Projectile"))
        {
            accuracyChecker.hasHitObstacle = true;
        }
    }
}
