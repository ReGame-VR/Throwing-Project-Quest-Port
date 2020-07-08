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
    public int totalThrowsAllowedPerLevel = 10;
    public AccuracyChecker accuracyChecker;
    public List<ButtonPressDetector> buttons = new List<ButtonPressDetector>();
    public int buttonsPressedTotal;
    public bool levelActivated = false;
    public LevelDifficulty levelDifficulty;


    // Start is called before the first frame update
    void Start()
    {
        accuracyChecker.ResetTotalThrows();
        buttonPanel.SetActive(true);
        instructionsText.text = "Press a button to choose a level difficulty.";
        buttonsPressedTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundCompleted())
        {
            //Reset Buttons State
            Debug.Log("----ROUND COMPLETE----");
        }

        LevelController();
    }

    public void LevelController()
    {
        int total = accuracyChecker.TotalThrows();
        //instructionsText.text = "Now lets practice throwing with differnt levels. Goodluck!";
        //throwCounterUI.text = throwsLeft.ToString();

        if (total >= totalThrowsAllowedPerLevel)
        {
            LevelComplete();
        }
    }
    
    public void LevelComplete()
    {
        //Might need to hide throwable object
        target.SetActive(false);
        platform.SetActive(false);
        levelDifficulty.DestroyObstacle();
        buttonPanel.SetActive(true);
        accuracyChecker.ResetTotalThrows();
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

    public bool RoundCompleted()
    {
        if(NumLevelsCompleted() == 5)
        {
            return true;
        }
        return false;
    }
}
