using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ConfManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buildInfoValText;
    [SerializeField] TMP_InputField udpDestHostnameInputField;
    [SerializeField] TMP_InputField udpDestPortInputField;
    [SerializeField] Toggle unixToggle;

    void Start()
    {
        buildInfoValText.SetText(
            Application.version + "\n"
            #if UNITY_ANDROID
            + new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationInfo").Get<int>("targetSdkVersion").ToString() + "\n"
            #else
            + "\n"
            #endif
            + Application.unityVersion + "\n"
            + Resources.Load<TextAsset>("BuildDatetime")
        );

        udpDestHostnameInputField.text = PlayerPrefs.GetString("UDP Dest Hostname");
        udpDestPortInputField.text = PlayerPrefs.GetInt("UDP Dest Port", -1) >= 0 ? PlayerPrefs.GetInt("UDP Dest Port").ToString() : null;
        unixToggle.isOn = PlayerPrefs.GetInt("Use UNIX Time Format") > 0;
    }

    public void OnChangeUnixToggle()
    {
        PlayerPrefs.SetInt("Use UNIX Time Format", unixToggle.isOn ? 1 : 0);
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
