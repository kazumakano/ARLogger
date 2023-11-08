using UnityEngine;
using TMPro;


public class ConfManager : MonoBehaviour
{
    [SerializeField] TMP_InputField udpDestHostnameInputField;
    [SerializeField] TMP_InputField udpDestPortInputField;

    void Start()
    {
        udpDestHostnameInputField.text = PlayerPrefs.GetString("UDP Dest Hostname");
        udpDestPortInputField.text = PlayerPrefs.GetInt("UDP Dest Port", -1) >= 0 ? PlayerPrefs.GetInt("UDP Dest Port").ToString() : null;
    }

    public void OnEndEditUdpDestHostname()
    {
        PlayerPrefs.SetString("UDP Dest Hostname", udpDestHostnameInputField.text);
    }

    public void OnEndEditUdpDestPort()
    {
        if (!int.TryParse(udpDestPortInputField.text, out int udpDestPort))
        {
            udpDestPort = -1;
        }
        PlayerPrefs.SetInt("UDP Dest Port", udpDestPort);
    }
}
