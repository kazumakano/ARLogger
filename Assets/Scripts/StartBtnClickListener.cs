using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StartBtnClickListener : BtnClickListener
{
    [SerializeField] TMP_InputField metaInfoInputField;

    void SetMetaInfo(Scene scene, LoadSceneMode mode)
    {
        PoseWriter poseWriter = GameObject.FindWithTag("Log Session").GetComponent<PoseWriter>();
        poseWriter.metaInfo = metaInfoInputField.text;
        SceneManager.sceneLoaded -= SetMetaInfo;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetMetaInfo;
        SceneManager.LoadScene(sceneName);
    }
}
