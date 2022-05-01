using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] TextMeshProUGUI posText;

    void FixedUpdate()
    {
        Display(camera.transform.position, camera.transform.rotation);
    }

    void Display(Vector3 pos, Quaternion rot)
    {
        posText.SetText($"x: {pos.x}\n" + $"y: {pos.x}\n" + $"z: {pos.z}\n");
    }
}
