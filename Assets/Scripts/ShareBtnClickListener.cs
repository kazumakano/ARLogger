using UnityEngine;
using System;


public class ShareBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    public void OnClick()
    {
        Intent.ShareFile(file, "text/csv");
    }
}
