using System;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class DelBtnDownListener : BtnDownListener
{
    [NonSerialized] public string file;

    protected override void OnTimeout()
    {
        File.Delete(file);
        Debug.Log($"{file} has been deleted", this);
        File.Delete(Path.ChangeExtension(file, ".meta"));
        SceneManager.LoadScene(sceneName);
    }
}
