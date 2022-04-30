using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] new GameObject camera;
    [SerializeField] TextMeshProUGUI posText;

    void FixedUpdate()
    {
        Display(camera.transform.position, camera.transform.rotation);
    }

    void Display(Vector3 pos, Quaternion rot)
    {
        posText.text = $"x: {pos.x}\n" + $"y: {pos.y}\n" + $"z: {pos.z}\n";
    }
}
