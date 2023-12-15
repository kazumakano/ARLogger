using UnityEngine;


public class ScreenKeeper : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void OnDestroy()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }
}
