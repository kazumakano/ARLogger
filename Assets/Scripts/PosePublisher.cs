using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;


public class PosePublisher : MonoBehaviour
{
    [SerializeField] Camera cam;

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
        byte[] msg = Encoding.UTF8.GetBytes($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{cam.transform.position.x},{cam.transform.position.y},{cam.transform.position.z},{cam.transform.rotation.x},{cam.transform.rotation.y},{cam.transform.rotation.z},{cam.transform.rotation.w}");
        client.Send(msg, msg.Length);
    }

    void OnDestroy()
    {
        client?.Close();
    }
}
