using UnityEngine;
using TMPro;


public class PositionDisplayer : MonoBehaviour
{
    [SerializeField] new GameObject camera;
    [SerializeField] TextMeshProUGUI posText;

    private PositionWriter posWriter;

    void Start()
    {
        posWriter = this.GetComponent<PositionWriter>();
    }

    private void Display(Vector3 pos)
    {
        posText.text = $"x: {pos.x}\n" + $"y: {pos.y}\n" + $"z: {pos.z}\n";
    }

    void FixedUpdate()
    {
        Display(camera.transform.position);
    }

    void Update()
    {
        posWriter.Write(camera.transform.position);
    }
}
