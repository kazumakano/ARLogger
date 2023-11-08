using UnityEngine;


public static class Vibration
{
    static readonly AndroidJavaObject vibrator = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getSystemService", "vibrator");

    public static void Vibrate(long len)
    {
        vibrator.Call("vibrate", len);
    }
}
