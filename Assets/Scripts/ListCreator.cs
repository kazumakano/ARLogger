using UnityEngine;
using TMPro;


public class ListCreator : MonoBehaviour
{
    [SerializeField] GameObject logFilePanelPrefab;

    void Start()
    {
        Transform content = GameObject.FindWithTag("Log File Scroll View").transform.Find("Viewport/Content");

        for (int i = 0; i < 20; i++) {
            GameObject logFilePanel = Instantiate<GameObject>(logFilePanelPrefab, content);
            logFilePanel.transform.Find("Text").GetComponent<TextMeshProUGUI>().SetText(i.ToString());
        }
    }
}
