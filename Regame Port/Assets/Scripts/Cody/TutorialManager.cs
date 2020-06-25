using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public GameObject target;
    public AccuracyChecker accuracyChecker;
    public GameObject throwCounter;
    public TextMeshProUGUI throwCounterUI;
    public int totalPracticeThrows = 10;

    // Update is called once per frame
    void Update()
    {
        if (globalControl.handCheck && !globalControl.hasWatchedInstructions)
        {
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
            heightCalibration.SetActive(true);
            levelScaler.SetActive(true);
            target.SetActive(true);
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && globalControl.hasCalibrated)
        {
            instructionsText.text = "Lets practice with a few throws. Grab the cube with the trigger and throw it in the basket! Goodluck!";
            throwCounter.SetActive(true);
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && globalControl.hasCalibrated && !hasCompletedPractice)
        {
            int total = accuracyChecker.TotalThrows();
            if(total == totalPracticeThrows)
            {
                hasCompletedPractice = true;
            }

            if (total <= totalPracticeThrows)
            {
                int throwsLeft = totalPracticeThrows - total;
                throwCounterUI.text = throwsLeft.ToString();
            }
        }
    }
}
