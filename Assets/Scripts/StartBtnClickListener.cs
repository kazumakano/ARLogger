using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;


public class StartBtnClickListener : BtnClickListener
{
    [SerializeField] TMP_InputField metaInfoInputField;
    [SerializeField] Toggle publisherToggle;
    [SerializeField] Toggle recorderToggle;

    void ActivatePublisher(Scene scene, LoadSceneMode mode)
    {
        if (publisherToggle.isOn)
        {
            string file = Path.Combine(Application.persistentDataPath, "config.json");
            if (File.Exists(file))
            {
                Conf conf = JsonUtility.FromJson<Conf>(File.ReadAllText(file));
                if (conf.UdpDestHostname != "" && conf.UdpDestPort >= 0)
                {
                    PosePublisher publisher = GameObject.FindWithTag("Log Session").GetComponent<PosePublisher>();
                    publisher.enabled = true;
                    publisher.hostname = conf.UdpDestHostname;
                    publisher.port = conf.UdpDestPort;
                }
            }
        }
        SceneManager.sceneLoaded -= ActivatePublisher;
    }

    void ActivateRecorder(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("AR Session").GetComponent<Recorder>().enabled = recorderToggle.isOn;
        SceneManager.sceneLoaded -= ActivateRecorder;
    }

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

    public override void OnClick()
    {
        SceneManager.sceneLoaded += ActivatePublisher;
        SceneManager.sceneLoaded += ActivateRecorder;
        SceneManager.sceneLoaded += SetFileName;
        SceneManager.sceneLoaded += SetMetaInfo;
        SceneManager.LoadScene(sceneName);
    }
}
