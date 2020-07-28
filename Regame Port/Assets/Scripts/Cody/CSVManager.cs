using System;
using UnityEngine;
using System.IO;

public class CSVManager : MonoBehaviour {
    
    private string path;
    private string reportDirectoryName = "Report";
    private string reportFileName = "report.csv";
    private string reportSeparator = ",";
    private string[] reportHeaders = new string[7] {
        "Participant ID",
        "Date",
        "Time",
        "Level",
        "Throw Number",
        "Error",
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

    public string[] DataInputToArray(string partId, string date, string time, string level, string throwNum, string error, string success)
    {
        string[] data = new string[7];
        data[0] = partId;
        data[1] = date;
        data[2] = time;
        data[3] = level;
        data[4] = throwNum;
        data[5] = error;
        data[6] = success;

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
        //path = "Assets/Resources/ResultsLog.csv";
        path = Application.persistentDataPath + "/Data.csv";
    }

    #endregion


#region Queries

    private string GetFilePath() {
        return path;
    }

#endregion

}
