using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogTestResults : MonoBehaviour
{
    // Path of file
    private string path;

    //---------------Added-------------//
    private GlobalControl globalControl;

    // Called on startup
    private void Start()
    {
        //----------------Added-----------------//
        globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();

        // Set path of file 
        //FOR RIFT USE ONLY 
        //path = "Assets/Resources/ResultsLog.txt";
        path = "Assets/Resources/ResultsLog.csv";

        //FOR QUEST USE ONLY 
        //path = Application.persistentDataPath + "/test.txt";

        LogCurrentTest();
    }

    // Function to avoid duplicate file creation
    private void CheckForFile()
    {
        // Create file if it doesn't already exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Test Log\n");
        }
    }

    // Used to create text
    void LogCurrentTest()
    {
        CheckForFile();

        // Content to add
        //string content = "\nTest: " + System.DateTime.Now + "\n";

        string content = null;

        switch (globalControl.progression)
        {
            case GlobalControl.ProgressionType.Choice:
                content = "\nTest #C_" + globalControl.participantID + " " + System.DateTime.Now + "\n";
                break;
            case GlobalControl.ProgressionType.Performance:
                content = "\nTest #P_" + globalControl.participantID + " " + System.DateTime.Now + "\n";
                break;
            case GlobalControl.ProgressionType.Random:
                content = "\nTest #R_" + globalControl.participantID + " " + System.DateTime.Now + "\n";
                break;
            default:
                break;
        }

        //Original format
        //string content = "\nTest: " + globalControl.participantID + " " + System.DateTime.Now + "\n";

        // Add the message to the file
        File.AppendAllText(path, content);
    }

    // Public function to add any string to a file
    public void AddText(string content)
    {
        content += "\n";
        File.AppendAllText(path, content);
    }
}
