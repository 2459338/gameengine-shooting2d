using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x
    public float fallSpeed = 5f;       // �������x

    void Update()
    {
        // ��]
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // ����
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
