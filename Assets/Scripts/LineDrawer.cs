using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;


public class LineDrawer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI filePathText;
    [SerializeField] GameObject linePrefab;
    [SerializeField] Slider scaleSlider;

    [NonSerialized] public string file;
    LineRenderer lineRenderer;
    Vector3[] posesArray;

    void Start()
    {
        filePathText.SetText(file);

        List<Vector3> posesList = new List<Vector3>();
        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine().Split(',');
                posesList.Add(new Vector3(float.Parse(row[1]), float.Parse(row[2]), float.Parse(row[3])));
            }
        }
        posesArray = posesList.ToArray();

        lineRenderer = Instantiate<GameObject>(linePrefab).GetComponent<LineRenderer>();
        lineRenderer.positionCount = posesArray.Length;
        OnScaleChanged();
    }

    public void OnScaleChanged()
    {
        Vector3[] scaledPosesArray = new Vector3[posesArray.Length];
        for (int i = 0; i < posesArray.Length; i++)
        {
            scaledPosesArray[i] = (float) Math.Pow(10, scaleSlider.value) * posesArray[i];
        }
        lineRenderer.SetPositions(scaledPosesArray);
    }
}
