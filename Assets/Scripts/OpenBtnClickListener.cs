using UnityEngine;
using System;


public class OpenBtnClickListener : MonoBehaviour
{
    [NonSerialized] public string file;

    public void OnClick()
    {
        Intent.OpenFile(file, "text/csv");
    }
}
