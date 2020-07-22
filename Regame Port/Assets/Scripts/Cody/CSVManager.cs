using UnityEngine;
using System.IO;

public static class CSVManager {
    
    //public static string path = "Assets/Resources/ResultsLog.csv";
    public static string path = Application.persistentDataPath + "./Data/test.txt";
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[7] {
        "Part_ID",
        "Date",
        "Time",
        "Level",
        "Throw Number",
        "Error",
        "Success(Y/N)"
    };
    private static string timeStampHeader = "Time Stamp";

#region Interactions

    public static void AppendToReport(string[] strings) {
        VerifyFile();
        using (StreamWriter sw = File.AppendText(path)) {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    private static void CreateReport() {
        using (StreamWriter sw = File.CreateText(path)) {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    public static string[] DataInputToArray(string partId, string date, string time, string level, string throwNum, string error, string success)
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

    public static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }

#endregion


#region Queries

    static string GetFilePath() {
        return path;
    }

    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.ToLocalTime().ToString();
    }

#endregion

}
