using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject explosionPrefab;  // 爆発のプレファブを設定するフィールド

    void OnTriggerEnter2D(Collider2D other)
    {
        // 弾に当たった場合
        if (other.CompareTag("Bullet"))
        {
            // 爆発のプレファブをボスの位置に生成
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 弾を破壊
            Destroy(other.gameObject);

            // 必要ならボス自身のダメージ処理や他の処理を追加する
            // Destroy(gameObject); // ボスが破壊される場合
        }
    }
}
