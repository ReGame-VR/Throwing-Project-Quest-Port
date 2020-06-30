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
    public bool hasCompletedLevelPractice = false;
    public GameObject target;
    public AccuracyChecker accuracyChecker;
    public GameObject throwCounter;
    public TextMeshProUGUI throwCounterUI;
    public int totalPracticeThrows = 10;
    public LevelDifficulty levelDifficulty;

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
                accuracyChecker.ResetTotalThrows();
            }
            if (total <= totalPracticeThrows)
            {
                int throwsLeft = totalPracticeThrows - total;
                throwCounterUI.text = throwsLeft.ToString();
            }
        }

        if (globalControl.handCheck && globalControl.hasWatchedInstructions && globalControl.hasCalibrated && hasCompletedPractice && !hasCompletedLevelPractice)
        {
            int total = accuracyChecker.TotalThrows();
            int throwsLeft = totalPracticeThrows - total;
            instructionsText.text = "Now lets practice throwing with differnt levels. Goodluck!";
            throwCounterUI.text = throwsLeft.ToString();

            if (throwsLeft <= totalPracticeThrows && throwsLeft > totalPracticeThrows - 2 && !levelDifficulty.one)
            {
                levelDifficulty.LevelOne();
                levelDifficulty.one = true;
            }
            if (throwsLeft <= totalPracticeThrows - 2 && throwsLeft > totalPracticeThrows - 4 && !levelDifficulty.two)
            {
                levelDifficulty.LevelTwo();
                levelDifficulty.two = true;
            }
            if (throwsLeft <= totalPracticeThrows - 4 && throwsLeft > totalPracticeThrows - 6 && !levelDifficulty.three)
            {
                levelDifficulty.LevelThree();
                levelDifficulty.three = true;
            }
            if (throwsLeft <= totalPracticeThrows - 6 && throwsLeft > totalPracticeThrows - 8 && !levelDifficulty.four)
            {
                levelDifficulty.LevelFour();
                levelDifficulty.four = true;
            }
            if (throwsLeft <= totalPracticeThrows - 8 && throwsLeft > totalPracticeThrows - 10 && !levelDifficulty.five)
            {
                levelDifficulty.LevelFive();
                levelDifficulty.five = true;
            }
            if(total == totalPracticeThrows)
            {
                hasCompletedLevelPractice = true;
            }
        }
    }
}
