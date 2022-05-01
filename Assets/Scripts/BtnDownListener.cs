using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnDownListener : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] string sceneName;

    bool isDown = false;
    float time = 0;

    void Update()
    {
        if (isDown)
        {
            time += Time.deltaTime;
        }
        if (time > duration)
        {
            SceneManager.LoadScene(sceneName);
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
