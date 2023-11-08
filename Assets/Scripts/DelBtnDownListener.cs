using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DelBtnDownListener : BtnDownListener
{
    [NonSerialized] public string file;

    protected override void OnTimeout()
    {
        File.Delete(file);
        Debug.Log($"{file} has been deleted", this);
        File.Delete(Path.ChangeExtension(file, ".meta"));
        File.Delete(Path.ChangeExtension(file, ".mp4"));
        Vibration.Vibrate(100);
        SceneManager.LoadScene(sceneName);
    }
}
