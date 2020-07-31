using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTrigger : MonoBehaviour
{
    public GameObject buttonPanelObject;
    public GameObject levelCompletionParent;
    public TextMeshProUGUI levelCompletionText;
    public GameObject percentagePanel;
    public GameObject instructionsPanel;
    public GameObject target;
    public ProjectileManager pm;
    public GameObject platform;
    public Gameplay gameplay;
    private float time = 0.0f;
    public float totalTimeToActivation = 0.0f;
    public MeshRenderer renderer;
    public AudioSource audioSource;
    public ButtonPanel buttonPanel;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent == null)
            return;

        if(other.transform.parent.name == "CustomHandLeft")
        {
            time += Time.deltaTime;
            renderer.material.color = Color.Lerp(Color.white, Color.blue, time);
            OVRInput.SetControllerVibration(.25f, .25f, OVRInput.Controller.LTouch);
            
            
            //place final round logic here 
            if (gameplay.hasCompletedFinalLevel && time > totalTimeToActivation && gameplay.totalLevelCount <= 4)
            {
                Debug.Log("Gameplay Trigger activated");
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.LTouch);
                platform.SetActive(true);
                levelCompletionParent.SetActive(false);
                percentagePanel.SetActive(false);
                target.SetActive(true);
                pm.ProjectileSwitch(true);
                audioSource.Play();
                levelCompletionText.text = "Nice Work!" +
                                           " Please take off your headset to talk to the researcher.";
                return;
            }
            
            
            if (time > totalTimeToActivation)
            {
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.LTouch);
                buttonPanelObject.SetActive(true);
                levelCompletionParent.SetActive(false);
                percentagePanel.SetActive(false);
                instructionsPanel.SetActive(true);
                target.SetActive(true);
                audioSource.Play();
                levelCompletionText.text = "Nice Work!" +
                                           " Please take off your headset to talk to the researcher.";

                buttonPanel.ButtonSwitch();
            }
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            time += Time.deltaTime;
            renderer.material.color = Color.Lerp(Color.white, Color.blue, time);
            OVRInput.SetControllerVibration(.25f, .25f, OVRInput.Controller.RTouch);
            
            
            //place final round logic here 
            if (gameplay.hasCompletedFinalLevel && time > totalTimeToActivation && gameplay.totalLevelCount <= 4)
            {
                Debug.Log("Gameplay Trigger activated");
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.RTouch);
                platform.SetActive(true);
                levelCompletionParent.SetActive(false);
                percentagePanel.SetActive(false);
                target.SetActive(true);
                pm.ProjectileSwitch(true);
                audioSource.Play();
                levelCompletionText.text = "Nice Work!" +
                                           " Please take off your headset to talk to the researcher.";
                return;
            }
            
            if (time > totalTimeToActivation)
            {
                OVRInput.SetControllerVibration(0.0f,0.0f, OVRInput.Controller.RTouch);
                buttonPanelObject.SetActive(true);
                levelCompletionParent.SetActive(false);
                percentagePanel.SetActive(false);
                instructionsPanel.SetActive(true);
                target.SetActive(true);
                audioSource.Play();
                levelCompletionText.text = "Nice Work!" +
                                           " Please take off your headset to talk to the researcher.";
                
                buttonPanel.ButtonSwitch();
            }
        }
    }

    public void ResetTrigger()
    {
        time = 0.0f;
        renderer.material.color = Color.white;
    }
}
