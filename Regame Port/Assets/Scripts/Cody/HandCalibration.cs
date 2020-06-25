using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class HandCalibration : MonoBehaviour
{
    public GlobalControl globalControl;

    /**
     * Checking if player has put in there dominant hand.
     * If they have, then we set their dominant hand
     * in the global control script. 
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null)
            return;

        if(other.transform.parent.name == "CustomHandLeft")
        {
            globalControl.isRightHanded = false;
            globalControl.handCheck = true;
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            globalControl.isRightHanded = true;
            globalControl.handCheck = true;
        }
    }
}
