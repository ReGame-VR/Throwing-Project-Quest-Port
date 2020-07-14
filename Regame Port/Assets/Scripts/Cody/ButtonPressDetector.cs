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
    private Vector3 initialPosition;
    public string setLevel;
    public LevelDifficulty levelDifficulty;
    public GameObject target;
    public GameObject targetParent;
    public GameObject platform;
    public Material buttonMaterial;
    public bool colorChanged = false;
    public GameObject buttonPanel;
    public GameObject walls;
    public AccuracyChecker accuracyChecker;
    public Gameplay gameplay;
    public ProjectileManager pm;
    public GameObject instructionPanel;
    public GameObject rightWall;
    public GameObject backpack;
    public LogTestResults logTestResults;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
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

        if (depthDistance >= buttonDepthValue && !buttonActivated)
        {
            buttonActivated = true;
            audioSource.Play();
            buttonRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            LevelSelection(this.gameObject.name);
            buttonPanel.SetActive(false);
            instructionPanel.SetActive(false);
            target.SetActive(true);
            platform.SetActive(true);
            pm.ProjectileSwitch(true);
            SwapColor(target, buttonMaterial);
            SwapColor(walls, buttonMaterial);
            SwapColor(platform, buttonMaterial);
            SwapColor(rightWall, buttonMaterial);
            SwapColor(backpack, buttonMaterial);
            accuracyChecker.ResetTotalThrows();
            pm.buttonActivator = true;
        }
    }

    public void LevelSelection(string level)
    {
        switch (level)
        {
            case "one":
                Debug.Log("Level one activated.");
                levelDifficulty.LevelOne();
                logTestResults.AddText("\nLevel One:");
                break;
            case "two":
                Debug.Log("Level two activated.");
                levelDifficulty.LevelTwo();
                logTestResults.AddText("\nLevel Two:");
                break;
            case "three":
                Debug.Log("Level three activated.");
                levelDifficulty.LevelThree();
                logTestResults.AddText("\nLevel Three:");
                break;
            case "four":
                Debug.Log("Level four activated.");
                levelDifficulty.LevelFour();
                logTestResults.AddText("\nLevel Four:");
                break;
            case "five":
                Debug.Log("Level five activated.");
                levelDifficulty.LevelFive();
                logTestResults.AddText("\nLevel Five:");
                break;
            default:
                break;
        }
    }

    public void SwapColor(GameObject objectToChange, Material newMat)
    {
        MeshRenderer meshRenderer = objectToChange.GetComponent<MeshRenderer>();
        Material[] oldMaterials = meshRenderer.materials;
        for(int i = 0; i < oldMaterials.Length; i++)
        {
            oldMaterials[i] = newMat;
        }
        meshRenderer.materials = oldMaterials;
    }

    public void ResetButtonPosition()
    {
        transform.position = initialPosition;
        buttonActivated = false;
        buttonRigidbody.constraints = ~RigidbodyConstraints.FreezePositionY;

    }
}
