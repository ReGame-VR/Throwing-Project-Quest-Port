using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailActivator : MonoBehaviour
{
    public GameObject trailFX;
    public TrailRenderer trailRenderer;
    public OVRGrabbable grabbaleobject;

    private void Update()
    {
        if (grabbaleobject.isGrabbed)
        {
            trailFX.SetActive(false);
            trailRenderer.Clear();
        }
        else
        {
            trailFX.SetActive(true);
        }
    }
}
