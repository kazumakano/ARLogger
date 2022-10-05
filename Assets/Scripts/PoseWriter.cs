using UnityEngine;
using TMPro;
using System;
using System.IO;


public class PoseWriter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TextMeshProUGUI filePathText;

    [NonSerialized] public string fileName;
    [NonSerialized] public string metaInfo;
    StreamWriter writer;

    void Start()
    {
        if (metaInfo != "")
        {
            using (writer = new StreamWriter(fileName + ".meta"))
            {
                writer.WriteLine(metaInfo);
            }
        }

        string file = fileName + ".csv";
        filePathText.SetText(file);
        writer = new StreamWriter(file);
        Debug.Log($"write to {file}", this);
    }

    void Update()
    {
        writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{cam.transform.position.x},{cam.transform.position.y},{cam.transform.position.z},{cam.transform.rotation.x},{cam.transform.rotation.y},{cam.transform.rotation.z},{cam.transform.rotation.w}");
    }

    void OnDestroy()
    {
        writer.Close();
    }
}
