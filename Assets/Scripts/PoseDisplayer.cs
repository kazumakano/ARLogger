using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] TextMeshProUGUI oriText;
    [SerializeField] TextMeshProUGUI posText;

    void FixedUpdate()
    {
        oriText.SetText($"α: {(camera.transform.eulerAngles.x + 180) % 360 - 180}\n" + $"β: {(camera.transform.eulerAngles.y + 180) % 360 - 180}\n" + $"γ: {(camera.transform.eulerAngles.z + 180) % 360 - 180}\n");
        posText.SetText($"x: {camera.transform.position.x}\n" + $"y: {camera.transform.position.y}\n" + $"z: {camera.transform.position.z}\n");
    }
}
