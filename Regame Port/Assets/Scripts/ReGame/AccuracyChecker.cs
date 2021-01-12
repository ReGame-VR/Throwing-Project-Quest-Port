using Oculus.Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

/*
 * Script tied to Target objects for tracking how many times a projectile
 * hits a target, and if it missed, how much it missed by.
 */
public class AccuracyChecker : MonoBehaviour
{
    // int values to track how many times a projectile designed for this target has hit this target or has missed
    public int numHit;
    public int numMiss;
    // Float value to track how far away the projectile landed from the target, in the event of a miss
    private float distAway;
    // References to TextMeshPro objects used to display above the target how many times it's been hit, missed, 
    // and whether the most recent shot hit or how much it missed by
    public TextMeshProUGUI hitCounter;
    //private String hitCounterText;
    public TextMeshProUGUI missCounter;
    //private String missCounterText;
    public TextMeshProUGUI distanceFromTarget;
    // String to allow easier modification of the distanceFromTarget TMPro's text field, since it will flip between
    // having hit and having missed
    private String distanceFromTargetText;
    // Reference to LogManager object in scene
    public GameObject logManager;
    // Reference to progressionScore object in scene
    public GameObject progressionScore;
    // Sound effects
    AudioSource successAudio;
    AudioSource missAudio;
    public ProjectileManager projectileManager;
    public GlobalControl globalControl;
    public CSVManager csvManager;
    public bool hasHitObstacle = false;

    // Start is called before the first frame update
    void Start()
    {
        // ints all start at 0
        numHit = 0;
        numMiss = 0;
        distAway = 0;
        // The distanceFromTarget TMPro will read the following before a projectile has been thrown
        distanceFromTargetText = "Please throw the projectile to begin.";
        // finds progressionScorer
        progressionScore = GameObject.Find("ProgressionScorer");
        // Finding the audio sources
        AudioSource[] audios = GetComponents<AudioSource>();
        successAudio = audios[0];
        missAudio = audios[1];
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the TMPros' text fields to mirror the current numbers of hits and misses, and whether
        // the last shot hit or missed
        hitCounter.text = "Hit: " + numHit;
        missCounter.text = "Missed: " + numMiss;
        distanceFromTarget.text = distanceFromTargetText;
    }

    // Called when another object enters the trigger area of this target object.
    private void OnTriggerEnter(Collider other)
    {
        var otherGameobject = other.gameObject;
        var groundChecker = otherGameobject.GetComponent<GroundChecker>();
        if (!groundChecker) return;
        
        string[] data = new string[9];

        if (groundChecker.tracking && otherGameobject.CompareTag("Projectile"))
        {
            // Update the hit counter
            numHit += 1;
            // Tell the projectile to invoke its Landed() function
            otherGameobject.SendMessage("Landed");
            // Update the distanceFromTargetText to reflect the successful hit
            distanceFromTargetText = "Target successfully hit!";

            // Play sound
            if (successAudio)
                successAudio.Play();

            // Tell the ProgressionScore object to log a hit
            if (progressionScore)
                progressionScore.GetComponent<ProgressionScoring>()?.ThrowComplete(true);

            //groundChecker.hasBeenGrabbed = false;

            /*data = csvManager.DataInputToArray(globalControl.participantID, System.DateTime.Now.ToString("d"),
                System.DateTime.Now.ToString("hh:mm:ss"), globalControl.currentLevel, TotalThrows().ToString(), distAway.ToString(), "Yes");*/
            
            data = csvManager.DataInputToArray(globalControl.participantID, System.DateTime.Now.ToString("d"),
                System.DateTime.Now.ToString("hh:mm:ss"), globalControl.currentLevel, TotalThrows().ToString(), "", hasHitObstacle.ToString(), "Yes");
            
            csvManager.AppendToReport(data);

            ResetObstacleDetector();
        }
    }

    // Function to handle when this target's projectile misses and hits the ground.
    public void Miss(Vector3 pos, GameObject projectile)
    {
        // Updates the miss counter
        numMiss += 1;
        // Calculates how far away the projectile landed from the target
        distAway = Math.Abs(Vector3.Distance(pos, this.transform.position));
        //  Updates the text string to reflect this
        distanceFromTargetText = "You missed by: " + distAway;
        // Play sound
        if (missAudio)
        {
            missAudio.Play();
        }

        string[] data = new string[9];
        data = csvManager.DataInputToArray(globalControl.participantID, System.DateTime.Now.ToString("d"),
            System.DateTime.Now.ToString("hh:mm:ss"), globalControl.currentLevel, TotalThrows().ToString(), distAway.ToString(), hasHitObstacle.ToString(),"No");

        csvManager.AppendToReport(data);
        
        ResetObstacleDetector();
    }
    

    public int TotalThrows()
    {
        return numHit + numMiss;
    }

    public void ResetTotalThrows()
    {
        numHit = 0;
        numMiss = 0;
    }

    public float PercentageOfSuccess()
    {
        return (float)numHit / (float)(numHit + numMiss);
    }

    private void ResetObstacleDetector()
    {
        hasHitObstacle = false;
    }
}
