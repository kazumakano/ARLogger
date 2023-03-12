using UnityEngine;
using UnityEngine.UI;


public class PublisherToggleActivator : MonoBehaviour
{
    [SerializeField] Button startBtn;

    void Start()
    {
        bool udpDestIsValid = false;
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("UDP Dest Hostname")) && PlayerPrefs.GetInt("UDP Dest Port", -1) >= 0)
        {
            StartBtnClickListener startBtnClickListener = startBtn.GetComponent<StartBtnClickListener>();
            startBtnClickListener.udpDestHostname = PlayerPrefs.GetString("UDP Dest Hostname");
            startBtnClickListener.udpDestPort = PlayerPrefs.GetInt("UDP Dest Port");
            udpDestIsValid = true;
        }
        GetComponent<Toggle>().interactable = udpDestIsValid;
    }
}
