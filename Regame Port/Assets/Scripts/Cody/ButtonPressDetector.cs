using JetBrains.Annotations;
using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressDetector : MonoBehaviour
{
    public float buttonDepthValue = .03f;
    public bool buttonActivated = false;
    public AudioSource audioSource;
    public Rigidbody buttonRigidbody;
    private float yStartPos;
    public string setLevel;
    public LevelDifficulty levelDifficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        yStartPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateButtonHeight();
    }

    public void CalculateButtonHeight()
    {
        float currentPos = transform.position.y;
        float depthDistance = yStartPos - currentPos;

        if(depthDistance >= buttonDepthValue && !buttonActivated)
        {
            buttonActivated = true;
            audioSource.Play();
            buttonRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            LevelSelection(setLevel);
        }
    }

    public void LevelSelection(string level)
    {
        switch (level)
        {
            case "one":
                Debug.Log("Level one activated.");
                levelDifficulty.one = true;
                break;
            case "two":
                Debug.Log("Level two activated.");
                levelDifficulty.two = true;
                break;
            case "three":
                Debug.Log("Level three activated.");
                levelDifficulty.three = true;
                break;
            case "four":
                Debug.Log("Level four activated.");
                levelDifficulty.four = true;
                break;
            case "five":
                Debug.Log("Level five activated.");
                levelDifficulty.five = true;
                break;
            default:
                break;
        }
    }
}
