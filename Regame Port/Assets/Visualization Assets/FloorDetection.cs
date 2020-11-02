using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    public GameObject trailFX;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            trailFX.transform.parent = null;
        }
    }
}
