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
}
