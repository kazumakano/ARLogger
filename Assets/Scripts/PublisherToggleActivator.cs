using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PublisherToggleActivator : MonoBehaviour
{
    [SerializeField] Button startBtn;

    void Start()
    {
        string file = Path.Combine(Application.persistentDataPath, "config.json");
        bool udpDestIsValid = false;
        if (File.Exists(file))
        {
            Conf conf = JsonUtility.FromJson<Conf>(File.ReadAllText(file));
            if (conf.UdpDestHostname != "" && conf.UdpDestPort >= 0)
            {
                StartBtnClickListener startBtnClickListener = startBtn.GetComponent<StartBtnClickListener>();
                startBtnClickListener.udpDestHostname = conf.UdpDestHostname;
                startBtnClickListener.udpDestPort = conf.UdpDestPort;
                udpDestIsValid = true;
            }
        }
        GetComponent<Toggle>().interactable = udpDestIsValid;
    }
}
