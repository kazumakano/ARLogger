using UnityEngine;
using TMPro;
using System;
using System.IO;


public class PoseWriter : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] TextMeshProUGUI filePathText;

    [NonSerialized] public string metaInfo;
    StreamWriter writer;

    void Start()
    {
        string fileName = Path.Combine(Application.persistentDataPath, DateTime.Now.ToString("yyyyMMdd-HHmmss"));

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
        writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{camera.transform.position.x},{camera.transform.position.y},{camera.transform.position.z},{camera.transform.rotation.x},{camera.transform.rotation.y},{camera.transform.rotation.z},{camera.transform.rotation.w}");
    }

    void OnDestroy()
    {
        writer.Close();
        Debug.Log("log file has been closed", this);
    }
}
