using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueOrExit : MonoBehaviour
{
    private float time = 0;
    public float totalTimeToActivation = 0.0f;
    public MeshRenderer renderer;
    public GameObject parent;
    public bool isContinue = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent == null)
            return;

        if(other.transform.parent.name == "CustomHandLeft")
        {
            time += Time.deltaTime;
            renderer.material.color = Color.Lerp(Color.white, Color.blue, time);
            OVRInput.SetControllerVibration(.25f, .25f, OVRInput.Controller.LTouch);
            
            if (time > totalTimeToActivation)
            {
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.LTouch);

                if (isContinue)
                {
                    parent.SetActive(false);
                }
                else
                {
                    Application.Quit();
                }
            }
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            time += Time.deltaTime;
            renderer.material.color = Color.Lerp(Color.white, Color.blue, time);
            OVRInput.SetControllerVibration(.25f, .25f, OVRInput.Controller.RTouch);
            
            if (time > totalTimeToActivation)
            {
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.RTouch);
                
                if (isContinue)
                {
                    parent.SetActive(false);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }
}
