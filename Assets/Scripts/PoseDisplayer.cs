using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] TextMeshProUGUI oriText;
    [SerializeField] TextMeshProUGUI posText;

    void FixedUpdate()
    {
        oriText.SetText($"α: {(cam.transform.eulerAngles.x + 180) % 360 - 180}\n" + $"β: {(cam.transform.eulerAngles.y + 180) % 360 - 180}\n" + $"γ: {(cam.transform.eulerAngles.z + 180) % 360 - 180}\n");
        posText.SetText($"x: {cam.transform.position.x}\n" + $"y: {cam.transform.position.y}\n" + $"z: {cam.transform.position.z}\n");
    }
}
