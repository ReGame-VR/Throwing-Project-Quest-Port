using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    public GlobalControl globalControl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent == null)
            return;

        if (other.transform.parent.name == "CustomHandLeft")
        {
            globalControl.hasWatchedInstructions = true;
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            globalControl.hasWatchedInstructions = true;
        }
    }
}
