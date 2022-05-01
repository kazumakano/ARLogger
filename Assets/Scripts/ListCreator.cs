using UnityEngine;
using System.IO;
using TMPro;


public class ListCreator : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject logFilePanelPrefab;

    void Start()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.csv");

        foreach (string file in files) {
            GameObject logFilePanel = Instantiate<GameObject>(logFilePanelPrefab, content.transform);
            logFilePanel.transform.Find("Delete Button").GetComponent<DelBtnClickListener>().file = file;
            logFilePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(Path.GetFileNameWithoutExtension(file));
        }
    }
}
