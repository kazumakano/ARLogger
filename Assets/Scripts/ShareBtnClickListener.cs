using System;
using UnityEngine;


public class ShareBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    public void OnClick()
    {
        Intent.ShareFile(file, "text/csv");
    }
}
