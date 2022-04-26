using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonListener : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
