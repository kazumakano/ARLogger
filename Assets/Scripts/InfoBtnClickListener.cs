using System;
using UnityEngine.SceneManagement;
using UnityEngine;


public class InfoBtnClickListener : BtnClickListener
{
    [NonSerialized] public string file;

    void SetFile(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("Info Session").GetComponent<InfoDisplayer>().file = file;
        SceneManager.sceneLoaded -= SetFile;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetFile;
        SceneManager.LoadScene(sceneName);
    }
}
