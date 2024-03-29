using UnityEngine;
using System.IO;
using TMPro;


public class ListCreator : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject logFilePanelPrefab;

    void Start()
    {
        foreach (string f in Directory.GetFiles(Application.persistentDataPath, "*.csv"))
        {
            GameObject logFilePanel = Instantiate<GameObject>(logFilePanelPrefab, content.transform);

            logFilePanel.GetComponent<ViewBtnClickListener>().file = f;
            logFilePanel.transform.Find("Delete Button").GetComponent<DelBtnDownListener>().file = f;
            logFilePanel.transform.Find("Info Button").GetComponent<InfoBtnClickListener>().file = f;
            logFilePanel.transform.Find("Share Button").GetComponent<ShareBtnClickListener>().file = f;
            logFilePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(Path.GetFileNameWithoutExtension(f));
        }
    }
}
