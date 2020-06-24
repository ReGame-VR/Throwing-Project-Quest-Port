using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandActivationSetting : MonoBehaviour
{
    public GlobalControl globalControl;
    public GameObject calibrationEnvironment;
    public GameObject handInstructions;

    /**
     * Checking if player has put in there dominant hand.
     * If they have, then we set their dominant hand
     * in the global control script. 
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.name == "CustomHandLeft")
        {
            globalControl.isRightHanded = false;
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            globalControl.isRightHanded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Turn on calibration scene when handedness has been set.
        calibrationEnvironment.SetActive(true);
        handInstructions.SetActive(false);


        //Disable this gameobject since handedness has been chosen.
        this.gameObject.SetActive(false);

    }
}
