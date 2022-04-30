using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class StartBtnClickListener : BtnClickListener
{
    public override void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
