using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;


public class StartBtnClickListener : BtnClickListener
{
    [SerializeField] TMP_InputField metaInfoInputField;
    [SerializeField] Toggle recorderToggle;

    void SetFileName(Scene scene, LoadSceneMode mode)
    {
        string fileName = Path.Combine(Application.persistentDataPath, DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        GameObject.FindWithTag("AR Session").GetComponent<Recorder>().file = fileName + ".mp4";
        GameObject.FindWithTag("Log Session").GetComponent<PoseWriter>().fileName = fileName;
        SceneManager.sceneLoaded -= SetFileName;
    }

    void SetMetaInfo(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("Log Session").GetComponent<PoseWriter>().metaInfo = metaInfoInputField.text;
        SceneManager.sceneLoaded -= SetMetaInfo;
    }

    void SetRecorder(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("AR Session").GetComponent<Recorder>().enabled = recorderToggle.isOn;
        SceneManager.sceneLoaded -= SetRecorder;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetFileName;
        SceneManager.sceneLoaded += SetMetaInfo;
        SceneManager.sceneLoaded += SetRecorder;
        SceneManager.LoadScene(sceneName);
    }
}
