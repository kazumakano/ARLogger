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
        posText.SetText("x: {0}\n" + "y: {1}\n" + "z: {2}\n", pos.x, pos.y, pos.z);
    }
}
