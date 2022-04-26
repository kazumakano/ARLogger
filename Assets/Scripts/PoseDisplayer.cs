using UnityEngine;
using TMPro;


public class PoseDisplayer : MonoBehaviour
{
    [SerializeField] new GameObject camera;
    [SerializeField] TextMeshProUGUI posText;
    // [SerializeField] TextMeshProUGUI rotText;

    private PoseWriter poseWriter;

    void Start()
    {
        poseWriter = this.GetComponent<PoseWriter>();
    }

    private void Display(Vector3 pos, Quaternion rot)
    {
        posText.text = $"x: {pos.x}\n" + $"y: {pos.y}\n" + $"z: {pos.z}\n";
        // rotText.text = $"x: {rot.x}\n" + $"y: {rot.y}\n" + $"z: {rot.z}\n" + $"w: {rot.w}\n";
    }

    void FixedUpdate()
    {
        Display(camera.transform.position, camera.transform.rotation);
    }

    void Update()
    {
        poseWriter.Write(camera.transform.position, camera.transform.rotation);
    }
}
