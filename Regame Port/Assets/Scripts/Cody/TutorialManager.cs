using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialManager : MonoBehaviour
{
    public GlobalControl globalControl;
    public GameObject handSelection;
    public GameObject videoDisplay;
    public GameObject videoInstructions;
    public bool hasCompletedPractice = false;
    public TextMeshProUGUI instructionsText;
    public GameObject heightCalibration;
    public GameObject levelScaler;
    public bool hasCalibrated = false;
    public bool hasCompletedTutorial = false;
    public GameObject target;
    public AccuracyChecker accuracyChecker;
    public GameObject throwCounter;
    public TextMeshProUGUI throwCounterUI;
    public int totalPracticeThrows = 10;
    public LevelDifficulty levelDifficulty;
    public LogTestResults logTestResults;
    private bool testResultsWritten = false;
    public GameObject platform;
    public ProjectileManager projectileManager;
    public ButtonPanel buttonPanel;
    public AudioManager audioManager;
    public bool hasPlayedCalibration = false;
    public bool hasPlayedPractice = false;
    public bool hasPlayedVideo = false;
    private float waitOnStart = 2f;

    private void Start()
    {
        //StartCoroutine(WaitOnStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (globalControl.handCheck && !globalControl.hasWatchedInstructions)
        {
            if (!hasPlayedVideo)
            {
                audioManager.PlayAudio(1);
                //Debug.Log("Played 1");
                hasPlayedVideo = true;
            }
            
            handSelection.SetActive(false);
            videoDisplay.SetActive(true);
            videoInstructions.SetActive(true);
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions)
        {
            videoDisplay.SetActive(false);
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && !globalControl.hasCalibrated)
        {
            instructionsText.text = "Before we practice, lets calibrate your height! Put your arm out to your side and press the button.";
            
            if (!hasPlayedVideo)
            {
                audioManager.PlayAudio(2);
                //Debug.Log("Played 2");
                hasPlayedVideo = true;
            }

            heightCalibration.SetActive(true);
            levelScaler.SetActive(true);
            target.SetActive(true);
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && globalControl.hasCalibrated)
        {
            instructionsText.text = "Let’s practice a few throws! Pick up the ball by pulling the trigger. Let go of the trigger while you throw the ball.";
            
            if (!hasPlayedPractice)
            {
                audioManager.PlayAudio(2);
                //Debug.Log("Played 2");
                hasPlayedPractice = true;
            }

            throwCounter.SetActive(true);

            if (!testResultsWritten)
            {
                testResultsWritten = true;
            }
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && globalControl.hasCalibrated && !hasCompletedPractice)
        {
            int total = accuracyChecker.TotalThrows();
            if(total == totalPracticeThrows)
            {
                hasCompletedPractice = true;
                accuracyChecker.ResetTotalThrows();
                hasCompletedTutorial = true;
                levelDifficulty.FullReset();
                projectileManager.ProjectileSwitch(false);
                platform.SetActive(false);
                
                buttonPanel.ButtonSwitch();
                
                this.gameObject.SetActive(false);
            }
            if (total <= totalPracticeThrows)
            {
                int throwsLeft = totalPracticeThrows - total;
                throwCounterUI.text = "You have " + throwsLeft.ToString() + " left!";
            }
        }
    }

    private IEnumerator WaitOnStart()
    {
        yield return new WaitForSeconds(waitOnStart);
        if (!hasPlayedCalibration)
        {
            audioManager.PlayAudio(0);
            //Debug.Log("Played 0");
            hasPlayedCalibration = true;
        }
    }
}
