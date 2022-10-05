using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PublisherToggleActivator : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    void Start()
    {
        string file = Path.Combine(Application.persistentDataPath, "config.json");
        bool subscriberIsValid = false;
        if (File.Exists(file))
        {
            Conf conf = JsonUtility.FromJson<Conf>(File.ReadAllText(file));
            if (conf.UdpDestHostname != "" && conf.UdpDestPort >= 0)
            {
                PosePublisher publisher = GameObject.FindWithTag("Log Session").GetComponent<PosePublisher>();
                publisher.hostname = conf.UdpDestHostname;
                publisher.port = conf.UdpDestPort;
                subscriberIsValid = true;
            }
        }
        toggle.interactable = subscriberIsValid;
    }
}
