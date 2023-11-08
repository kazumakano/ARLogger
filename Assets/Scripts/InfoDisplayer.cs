using UnityEngine;
using TMPro;
using System;
using System.IO;

public class InfoDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;

    [NonSerialized] public string file;

    void Start()
    {
        string infoTextStr = $"file: {file}\n";

        long fileSize = new FileInfo(file).Length;
        switch (fileSize)
        {
            case long l when l < 1024:
                infoTextStr += $"size: {fileSize} B\n";
                break;
            case long l when l < Math.Pow(1024, 2):
                infoTextStr += $"size: {fileSize / 1024.0:F1} KB\n";
                break;
            default:
                infoTextStr += $"size: {fileSize / Math.Pow(1024, 2):F1} MB\n";
                break;
        }

        if (File.Exists(Path.ChangeExtension(file, ".meta")))
        {
            using (StreamReader reader = new(Path.ChangeExtension(file, ".meta")))
            {
                infoTextStr += $"meta info: {reader.ReadLine()}\n";
            }
        }

        infoText.SetText(infoTextStr);
    }
}
