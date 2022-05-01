using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DelBtnClickListener : BtnClickListener
{
    [NonSerialized] public string file;

    public override void OnClick()
    {
        File.Delete(file);
        Debug.Log($"{Path.GetFileName(file)} has been deleted");
        File.Delete(Path.ChangeExtension(file, ".meta"));
        SceneManager.LoadScene(sceneName);
    }
}
