using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.IO;


public class LineDrawer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI filePathText;
    [SerializeField] GameObject linePrefab;

    [NonSerialized] public string file;

    void Start()
    {
        filePathText.SetText(file);

        List<Vector3> poses = new List<Vector3>();
        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine().Split(',');
                poses.Add(new Vector3(float.Parse(row[1]) / 10, float.Parse(row[2]) / 10, float.Parse(row[3]) / 10));
            }
        }

        LineRenderer renderer = Instantiate<GameObject>(linePrefab).GetComponent<LineRenderer>();
        renderer.positionCount = poses.Count;
        renderer.SetPositions(poses.ToArray());
    }
}
