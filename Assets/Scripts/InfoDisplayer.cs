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
        infoTextStr += $"size: {new FileInfo(file).Length} bytes\n";
        if (File.Exists(Path.ChangeExtension(file, ".meta")))
        {
            using (StreamReader reader = new StreamReader(Path.ChangeExtension(file, ".meta")))
            {
                infoTextStr += $"meta info: {reader.ReadLine()}\n";
            }
        }

        infoText.SetText(infoTextStr);
    }
}
