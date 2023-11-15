using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;


public class ShareBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    public void OnClick()
    {
        List<string> files = new() { file };
        if (File.Exists(Path.ChangeExtension(file, ".meta")))
        {
            files.Add(Path.ChangeExtension(file, ".meta"));
        }
        if (File.Exists(Path.ChangeExtension(file, ".mp4")))
        {
            files.Add(Path.ChangeExtension(file, ".mp4"));
        }

        Intent.ShareFile(files, "*/*");
    }
}
