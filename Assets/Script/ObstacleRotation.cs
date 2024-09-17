using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度
    public float fallSpeed = 5f;       // 落下速度

    void Update()
    {
        // 回転
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // 落下
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
