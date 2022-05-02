using System;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class DelBtnDownListener : BtnDownListener
{
    [NonSerialized] public string file;

    protected override void Update()
    {
        if (isDown)
        {
            time += Time.deltaTime;
            if (time > duration)
            {
                File.Delete(file);
                Debug.Log($"{file} has been deleted", this);
                File.Delete(Path.ChangeExtension(file, ".meta"));
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
