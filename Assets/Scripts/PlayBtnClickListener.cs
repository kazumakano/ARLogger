using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;


public class PlayBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    void Start()
    {
        foreach (Image i in GetComponentsInChildren<Image>())
        {
            i.enabled = File.Exists(file);
        }
    }

    public void OnClick()
    {
        Intent.OpenFile(file, "video/mp4");
    }
}
