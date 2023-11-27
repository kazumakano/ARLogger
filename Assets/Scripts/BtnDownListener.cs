using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnDownListener : MonoBehaviour
{
    const long VIB_LEN = 100;

    [SerializeField] float duration;
    [SerializeField] protected string sceneName;

    bool isDown = false;
    float time = 0;

    void Update()
    {
        if (isDown)
        {
            time += Time.deltaTime;
            if (time > duration)
            {
                OnTimeout();
                Vibration.Vibrate(VIB_LEN);
            }
        }
    }

    protected virtual void OnTimeout()
    {
        SceneManager.LoadScene(sceneName);
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
