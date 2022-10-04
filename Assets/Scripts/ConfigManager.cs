using UnityEngine;
using TMPro;
using System.IO;
using System;


class Conf
{
    public string UdpDestHostname;
    public int UdpDestPort;

    public Conf()
    {
        UdpDestHostname = "";
        UdpDestPort = -1;
    }
}

public class ConfigManager : MonoBehaviour
{
    [SerializeField] TMP_InputField udpDestHostnameInputField;
    [SerializeField] TMP_InputField udpDestPortInputField;

    Conf conf;
    string file;

    void Start()
    {
        file = Path.Combine(Application.persistentDataPath, "config.json");

        if (File.Exists(file))
        {
            conf = JsonUtility.FromJson<Conf>(File.ReadAllText(file));
            udpDestHostnameInputField.text = conf.UdpDestHostname;
            udpDestPortInputField.text = conf.UdpDestPort >= 0 ? conf.UdpDestPort.ToString() : "";
        }
        else
        {
            conf = new Conf();
        }
    }

    public void OnEndEditUdpDestHostname()
    {
        conf.UdpDestHostname = udpDestHostnameInputField.text;
        File.WriteAllText(file, JsonUtility.ToJson(conf));
    }

    public void OnEndEditUdpDestPort()
    {
        if (!Int32.TryParse(udpDestPortInputField.text, out conf.UdpDestPort))
        {
            conf.UdpDestPort = -1;
        }
        File.WriteAllText(file, JsonUtility.ToJson(conf));
    }
}
