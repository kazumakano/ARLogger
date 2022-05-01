using UnityEngine;
using System.IO;
using TMPro;


public class ListCreator : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject logFilePanelPrefab;

    void Start()
    {
        foreach (string f in Directory.GetFiles(Application.persistentDataPath, "*.csv")) {
            GameObject logFilePanel = Instantiate<GameObject>(logFilePanelPrefab, content.transform);

            logFilePanel.GetComponent<DrawBtnClickListener>().file = f;
            logFilePanel.transform.Find("Delete Button").GetComponent<DelBtnClickListener>().file = f;
            logFilePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(Path.GetFileNameWithoutExtension(f));
        }
    }
}
