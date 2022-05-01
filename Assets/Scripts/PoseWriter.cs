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

        if (metaInfo != "") {
            writer = new StreamWriter(fileName + ".meta");
            writer.WriteLine(metaInfo);
            writer.Close();
        }

        string file = Path.Combine(fileName + ".csv");
        filePathText.SetText(file);
        writer = new StreamWriter(file);
        Debug.Log($"write to {file}", this);
    }

    void Update()
    {
        Write(camera.transform.position, camera.transform.rotation);
    }

    void OnDestroy()
    {
        writer.Close();
        Debug.Log("log file has been closed", this);
    }

    void Write(Vector3 pos, Quaternion rot)
    {
        writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{pos.x},{pos.y},{pos.z},{rot.x},{rot.y},{rot.z},{rot.w}");
    }
}
