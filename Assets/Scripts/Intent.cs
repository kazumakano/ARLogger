using UnityEngine;
using System.Collections.Generic;


public static class Intent
{
    #if UNITY_ANDROID
    static readonly AndroidJavaObject curAct = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    static readonly AndroidJavaObject ctx = curAct.Call<AndroidJavaObject>("getApplicationContext");
    static readonly string auth = ctx.Call<string>("getPackageName") + ".fileprovider";
    static readonly AndroidJavaClass fileProvider = new("android.support.v4.content.FileProvider");
    #endif

    public static void OpenFile(string file, string type)
    {
        #if UNITY_ANDROID
        AndroidJavaObject intent = new("android.content.Intent");
        intent.Call<AndroidJavaObject>("addFlags", intent.GetStatic<int>("FLAG_GRANT_READ_URI_PERMISSION"));
        intent.Call<AndroidJavaObject>("setAction", intent.GetStatic<string>("ACTION_VIEW"));
        intent.Call<AndroidJavaObject>(
            "setDataAndType",
            fileProvider.CallStatic<AndroidJavaObject>("getUriForFile", ctx, auth, new AndroidJavaObject("java.io.File", file)),
            type
        );
        curAct.Call("startActivity", intent);
        #endif
    }

    public static void ShareFile(List<string> files, string type)
    {
        #if UNITY_ANDROID
        AndroidJavaObject uris = new("java.util.ArrayList");
        foreach (string f in files)
        {
            uris.Call<bool>("add", fileProvider.CallStatic<AndroidJavaObject>("getUriForFile", ctx, auth, new AndroidJavaObject("java.io.File", f)));
        }

        AndroidJavaObject intent = new("android.content.Intent");
        intent.Call<AndroidJavaObject>("putExtra", intent.GetStatic<string>("EXTRA_STREAM"), uris);
        intent.Call<AndroidJavaObject>("setAction", intent.GetStatic<string>("ACTION_SEND_MULTIPLE"));
        intent.Call<AndroidJavaObject>("setType", type);
        curAct.Call("startActivity", intent);
        #endif
    }
}
