using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StartBtnClickListener : BtnClickListener
{
    [SerializeField] TMP_InputField metaInfoInputField;

    void SetMetaInfo(Scene scene, LoadSceneMode mode)
    {
        GameObject.FindWithTag("Log Session").GetComponent<PoseWriter>().metaInfo = metaInfoInputField.text;
        SceneManager.sceneLoaded -= SetMetaInfo;
    }

    public override void OnClick()
    {
        SceneManager.sceneLoaded += SetMetaInfo;
        SceneManager.LoadScene(sceneName);
    }
}
