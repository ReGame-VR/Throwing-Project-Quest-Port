using System;
using UnityEngine;
using System.IO;

public class CSVManager : MonoBehaviour {
    
    private string path;
    public string reportFileName = "Data.csv";
    private string reportSeparator = ",";
    
    private string[] reportHeaders = new string[9] {
        "Participant ID",
        "Date",
        "Time",
        "Level",
        "Throw Number",
        "Error",
        "Has Hit Rim",
        "Has Hit Obstacle",
        "Success(Y/N)"
    };

#region Interactions

    public void AppendToReport(string[] strings) {
        VerifyFile();
        using (StreamWriter sw = File.AppendText(path)) {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            sw.WriteLine(finalString);
        }
    }

    private void CreateReport() {
        using (StreamWriter sw = File.CreateText(path)) {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            sw.WriteLine(finalString);
        }
    }

    public string[] DataInputToArray(string partId, string date, string time, string level, string throwNum, string error, string hasHitRim, string hasHitObstacle, string success)
    {
        string[] data = new string[9];
        data[0] = partId;
        data[1] = date;
        data[2] = time;
        data[3] = level;
        data[4] = throwNum;
        data[5] = error;
        data[6] = hasHitRim;
        data[7] = hasHitObstacle;
        data[8] = success;

        return data;
    }

#endregion


#region Operations

    private void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }

    private void Awake()
    {
        //Non-Quest version path
        //path = "Assets/Resources/ResultsLog.csv";
        
        //Quest Path as of 07/28/2020
        path = Application.persistentDataPath + "/" + reportFileName;
    }

    #endregion


#region Queries

    private string GetFilePath() {
        return path;
    }

#endregion

}
