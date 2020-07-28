using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogTestResults : MonoBehaviour
{
    public string path;
    private GlobalControl globalControl;

    // Called on startup
    private void Start()
    {
        globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();
        
        //FOR RIFT USE ONLY 
        //path = "Assets/Resources/ResultsLog.csv";

        //FOR QUEST USE ONLY 
        path = Application.persistentDataPath + "/test.txt";
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
        string content = "\nTest: " + System.DateTime.Now + "\n";

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
