using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonClickListener : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
