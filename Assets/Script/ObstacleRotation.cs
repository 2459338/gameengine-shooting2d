using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // ‰ñ“]‘¬“x
    public float fallSpeed = 5f;       // —Ž‰º‘¬“x

    void Update()
    {
        // ‰ñ“]
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // —Ž‰º
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
}
