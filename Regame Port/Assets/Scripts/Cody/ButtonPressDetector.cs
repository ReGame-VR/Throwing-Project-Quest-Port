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
    public GameObject target;
    public GameObject targetParent;
    public GameObject platform;
    public Material buttonMaterial;
    public bool colorChanged = false;
    public GameObject buttonPanel;

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
            buttonPanel.SetActive(false);
            targetParent.SetActive(true);
            platform.SetActive(true);
            SwapColorToTarget();
        }
    }

    public void LevelSelection(string level)
    {
        switch (level)
        {
            case "one":
                Debug.Log("Level one activated.");
                levelDifficulty.LevelOne();
                break;
            case "two":
                Debug.Log("Level two activated.");
                levelDifficulty.LevelTwo();
                break;
            case "three":
                Debug.Log("Level three activated.");
                levelDifficulty.LevelThree();
                break;
            case "four":
                Debug.Log("Level four activated.");
                levelDifficulty.LevelFour();
                break;
            case "five":
                Debug.Log("Level five activated.");
                levelDifficulty.LevelFive();
                break;
            default:
                break;
        }
    }

    public void SwapColorToTarget()
    {
        if (!colorChanged)
        {
            MeshRenderer meshRenderer = target.GetComponent<MeshRenderer>();
            // Get the current material applied on the GameObject
            Material oldMaterial = meshRenderer.material;
            Debug.Log("Applied Material: " + oldMaterial.name);
            // Set the new material on the GameObject
            meshRenderer.material = buttonMaterial;
            colorChanged = true;
        }
    }
}
