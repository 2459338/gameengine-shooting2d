using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public float offScreenY = -6f; // 画面外のY座標（調整が必要）

    void Update()
    {
        // 画面外に出たとき
        if (transform.position.y < offScreenY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たったとき
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
