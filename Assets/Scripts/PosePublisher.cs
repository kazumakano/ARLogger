using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;


public class PosePublisher : MonoBehaviour
{
    [SerializeField] new Camera camera;

    UdpClient client;
    [NonSerialized] public string hostname;
    [NonSerialized] public int port;

    void Start()
    {
        client = new UdpClient(hostname, port);
        Debug.Log($"connect to {hostname}:{port}", this);
    }

    void Update()
    {
        byte[] msg = Encoding.UTF8.GetBytes($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{camera.transform.position.x},{camera.transform.position.y},{camera.transform.position.z},{camera.transform.rotation.x},{camera.transform.rotation.y},{camera.transform.rotation.z},{camera.transform.rotation.w}");
        client.Send(msg, msg.Length);
    }

    void OnDestroy()
    {
        client.Close();
    }
}
