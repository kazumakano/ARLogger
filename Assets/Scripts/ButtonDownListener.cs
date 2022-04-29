using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonDownListener : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] string sceneName;

    private bool isDown = false;
    private float time = 0;

    void Update()
    {
        if (isDown) {
            time += Time.deltaTime;
        }
        if (time > duration) {
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
