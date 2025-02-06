using UnityEngine;
using System;
using System.IO;


public class PoseWriter : MonoBehaviour
{
    [SerializeField] Camera cam;

    [NonSerialized] public string fileName;
    [NonSerialized] public string metaInfo;
    Func<string> getTsStr;
    StreamWriter writer;

    void Start()
    {
        getTsStr = PlayerPrefs.GetInt("Use UNIX Time Format") > 0 ? () => (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds.ToString() : () => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");

        if (metaInfo != "")
        {
            using (writer = new StreamWriter(fileName + ".meta"))
            {
                writer.WriteLine(metaInfo);
            }
        }

        string file = fileName + ".csv";
        writer = new StreamWriter(file);
        Debug.Log($"write to {file}", this);
    }

    void Update()
    {
        writer.WriteLine($"{getTsStr()},{cam.transform.position.x},{cam.transform.position.y},{cam.transform.position.z},{cam.transform.rotation.x},{cam.transform.rotation.y},{cam.transform.rotation.z},{cam.transform.rotation.w}");
    }

    void OnDestroy()
    {
        writer.Close();
    }
}
