using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnDownListener : MonoBehaviour
{
    [SerializeField] protected float duration;
    [SerializeField] protected string sceneName;

    protected bool isDown = false;
    protected float time = 0;

    protected virtual void Update()
    {
        if (isDown)
        {
            time += Time.deltaTime;
            if (time > duration)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void OnDown()
    {
        isDown = true;
    }

    public void OnUp()
    {
        isDown = false;
        time = 0;
    }
}
