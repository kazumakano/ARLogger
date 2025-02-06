using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.IO;
using System;
using UnityEditor;


public class BuildDatetime : IPreprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPreprocessBuild(BuildReport report)
    {
        if (!Directory.Exists("Assets/Resources/"))
        {
            Directory.CreateDirectory("Assets/Resources/");
        }
        File.WriteAllText("Assets/Resources/BuildDatetime.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        AssetDatabase.Refresh();
    }
}
