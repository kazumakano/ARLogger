using UnityEngine;
using System;
using System.IO;


public class PlayBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    public void OnClick()
    {
        if (File.Exists(file))
        {
            Intent.OpenFile(file, "video/mp4");
        }
    }
}
