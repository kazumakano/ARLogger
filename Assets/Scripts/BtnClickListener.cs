using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnClickListener : MonoBehaviour
{
    [SerializeField] protected string sceneName;

    public virtual void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
