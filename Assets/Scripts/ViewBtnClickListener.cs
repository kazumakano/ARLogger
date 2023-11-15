using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


public class ViewBtnClickListener : BtnClickListener
{
    [NonSerialized] public string file;

    void SetFile(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("Open Button").GetComponent<OpenBtnClickListener>().file = file;
        GameObject.FindWithTag("Play Button").GetComponent<PlayBtnClickListener>().file = Path.ChangeExtension(file, ".mp4");
        GameObject.FindWithTag("View Session").GetComponent<LineDrawer>().file = file;
        SceneManager.sceneLoaded -= SetFile;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetFile;
        SceneManager.LoadScene(sceneName);
    }
}
