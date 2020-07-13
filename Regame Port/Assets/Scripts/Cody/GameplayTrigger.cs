using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTrigger : MonoBehaviour
{
    public GameObject buttonPanel;
    public GameObject levelCompletionParent;
    public GameObject percentagePanel;
    public Gameplay gameplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null)
            return;

        if (other.transform.parent.name == "CustomHandLeft")
        {
            //Activate button panel
            buttonPanel.SetActive(true);
            //remove instructions panel ad activate buttons
            levelCompletionParent.SetActive(false);
            percentagePanel.SetActive(false);
        }

        if (other.transform.parent.name == "CustomHandRight")
        {
            //Activate button panel
            buttonPanel.SetActive(true);
            //remove instructions panel ad activate buttons
            levelCompletionParent.SetActive(false);
            percentagePanel.SetActive(false);
        }
    }
}
