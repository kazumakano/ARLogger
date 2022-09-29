using UnityEngine;
using UnityEngine.SceneManagement;


public class StopBtnDownListener : BtnDownListener
{
    protected override void OnTimeout()
    {
        GameObject.FindWithTag("AR Session").GetComponent<Recorder>().Stop();
        SceneManager.LoadScene(sceneName);
    }
}
