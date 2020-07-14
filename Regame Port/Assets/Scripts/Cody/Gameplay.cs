using System;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public GameObject buttonPanel;
    public GameObject target;
    public GameObject platform;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI percentageOfThrows;
    public TextMeshProUGUI remainingThrows;
    public int totalThrowsAllowedPerLevel = 10;
    public AccuracyChecker accuracyChecker;
    public List<ButtonPressDetector> buttons = new List<ButtonPressDetector>();
    public int buttonsPressedTotal;
    public bool levelActivated = false;
    public LevelDifficulty levelDifficulty;
    public GameObject gameplayPanel;
    public GameObject percentagePanel;
    public GameObject instructionsPanel;
    public GameObject remainingThrowsPanel;
    public TextMeshProUGUI percentageText;
    public float completionPercent;
    public bool levelComplete = false;
    public ProjectileManager pm;
    public LogTestResults logTestResults;
    public GameObject completionPanel;
    private bool finalRound = false;
    private bool gameComplete = false;
    public int totalLevelCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        accuracyChecker.ResetTotalThrows();
        buttonPanel.SetActive(true);
        instructionsText.text = "Press a button to choose a level difficulty.";
        buttonsPressedTotal = 0;
        logTestResults.AddText("\n-------------Gameplay Beginning-------------");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameComplete)
        {
            if (RoundCompleted())
            {
                ResetButtons();
            }
            if (totalLevelCount == 6)
            {
                finalRound = true;
            }
            LevelController();
        }
        

    }

    public void LevelController()
    {
        int total = accuracyChecker.TotalThrows();
        //instructionsText.text = "Now lets practice throwing with differnt levels. Goodluck!";
        int throwsLeft = totalThrowsAllowedPerLevel - total;
        remainingThrows.text = throwsLeft.ToString();

        if (finalRound)
        {
            //LevelComplete();
            //Display panel instructing completion.
            remainingThrowsPanel.SetActive(false);
            completionPanel.SetActive(true);
            instructionsPanel.SetActive(false);
            gameplayPanel.SetActive(false);
            percentagePanel.SetActive(false);
            gameComplete = true;
            logTestResults.AddText("\n--------Complete--------");
            return;
        }

        if (total >= totalThrowsAllowedPerLevel)
        {
            LevelComplete();
        }
    }
    
    public void LevelComplete()
    {
        //Might need to hide throwable object
        pm.ProjectileSwitch(false);
        target.SetActive(false);
        platform.SetActive(false);
        levelDifficulty.DestroyObstacle();
        //buttonPanel.SetActive(true);
        //Pop up instructions to talk with instructor
        instructionsPanel.SetActive(true);
        gameplayPanel.SetActive(true);
        percentagePanel.SetActive(true);
        GetAccuracvPercentage();
        percentageText.text = String.Format("{0:0.0}", completionPercent) + "%";
        logTestResults.AddText("Success Rate = " + String.Format("{0:0.0}", completionPercent) + "%");
        accuracyChecker.ResetTotalThrows();
        pm.buttonActivator = false;
        AddLevelCount();
    }

    public int NumLevelsCompleted()
    {
        int totalButtonsPressed = 0;
        for(int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonActivated)
            {
                totalButtonsPressed++;
            }
        }
        return totalButtonsPressed;
    }

    public void AddLevelCount()
    {
        totalLevelCount++;
    }

    public bool RoundCompleted()
    {
        if(NumLevelsCompleted() == 5)
        {
            return true;
        }
        return false;
    }

    public void GetAccuracvPercentage()
    {
        completionPercent = accuracyChecker.PercentageOfSuccess();
        completionPercent *= 100.0f;
    }

    public void ResetButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].ResetButtonPosition();
        }
    }
}
