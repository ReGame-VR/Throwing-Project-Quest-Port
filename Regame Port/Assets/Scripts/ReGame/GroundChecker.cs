using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for checking whether a projectile has hit the ground. Handles whether the projectile
 * has hit the target or has missed the target.
 */
public class GroundChecker : MonoBehaviour
{
    // Reference to target-area object this projectile is meant to be thrown at
    public GameObject target;
    // Reference to the ProgressionScoring object that has to process hits and misses
    public GameObject progressionScore;
    // Private boolean value, true when projectile has yet to be thrown and hit ground, false once it has hit the ground.
    // Turns true upon reset. Exists to prevent it from bouncing or rolling into the goal, or from both hitting and missing in the
    // same toss by traveling through the target-area trigger into the ground and qualifying as a miss.
    //private bool tracking;
    public bool tracking;
    public ProjectileManager projectileManager;
    public OVRGrabbable grabbable;
    private GlobalControl _globalControl;
    public bool hasBeenGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        _globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();
        
        // On startup, the projectile will be tracked
        tracking = true;
        // Finds target in scene
        target = GameObject.FindGameObjectWithTag("Target");
        // Finds progressionScore
        progressionScore = GameObject.Find("ProgressionScorer");

        projectileManager = GameObject.Find("ProjectileManager").GetComponent<ProjectileManager>();
    }

    // When the projectile comes in contact with another collider
    private void OnCollisionEnter(Collision collision)
    {

        if (!target || !progressionScore) return;

        // If the projectile was tracking and hits the ground
        if (tracking && collision.gameObject.CompareTag("Ground"))
        {
            // Tell the target to run its Miss() function with the parameter of the projectile's current position
            //target.SendMessage("Miss", this.transform.position);
            target.GetComponent<AccuracyChecker>().Miss(this.transform.position, this.gameObject);
            // Tell the ProgressionScore object to log a miss
            progressionScore.GetComponent<ProgressionScoring>()?.ThrowComplete(false);
            // Run the projectile's landed() function
            //Landed();
            tracking = false;
            //hasBeenGrabbed = false;
        }
    }

    private void Update()
    {
        /*if (!grabbable.grabbedBy)
            return;
        
        if (grabbable.grabbedBy.ToString().Equals("CustomHandRight (OVRGrabber)") && !hasBeenGrabbed)
        {
            StartCoroutine(Haptics(.25f, .25f, .1f, true, false));
            hasBeenGrabbed = true;
        }
        if (grabbable.grabbedBy.ToString().Equals("CustomHandLeft (OVRGrabber)") && !hasBeenGrabbed)
        {
            StartCoroutine(Haptics(.25f, .25f, .1f, false, true));
            hasBeenGrabbed = true;
        }*/
    }


    // Function to let other scripts see if the projectile is still being tracked
    public bool GetTracking()
    {
        return tracking;
    }

    // Marks the projectile as no longer being tracked, has hit the ground
    private void Landed()
    {
        tracking = false;
    }

    // When projectile is reset, this function marks it as ready to be tracked again
    private void HasReset()
    {
        tracking = true;
    }
    
    IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if(rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        if(leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

        yield return new WaitForSeconds(duration);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
