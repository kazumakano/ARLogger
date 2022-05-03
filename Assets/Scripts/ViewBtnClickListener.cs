using System;
using UnityEngine.SceneManagement;
using UnityEngine;


public class ViewBtnClickListener : BtnClickListener
{
    [NonSerialized] public string file;

    void SetFile(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("View Session").GetComponent<LineDrawer>().file = file;
        SceneManager.sceneLoaded -= SetFile;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetFile;
        SceneManager.LoadScene(sceneName);
    }
}
