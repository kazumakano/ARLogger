using UnityEngine;


public static class Vibration
{
    #if UNITY_ANDROID
    static readonly AndroidJavaObject vibrator = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getSystemService", "vibrator");
    #endif

    public static void Vibrate(long len)
    {
        #if UNITY_ANDROID
        vibrator.Call("vibrate", len);
        #endif
    }
}
