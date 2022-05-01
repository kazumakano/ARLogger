using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] TextMeshProUGUI posText;

    void FixedUpdate()
    {
        posText.SetText($"x: {camera.transform.position.x}\n" + $"y: {camera.transform.position.y}\n" + $"z: {camera.transform.position.z}\n");
    }
}
