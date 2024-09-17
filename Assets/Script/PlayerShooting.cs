using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform shootingPoint; // 弾の発射位置
    public float bulletSpeed = 10f; // 弾の速度

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        // 弾に力を加えて発射
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }
}

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Inseki") || other.CompareTag("Alien"))
            {
                Debug.Log("Hit: " + other.tag);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }


        // その他のオブジェクトに当たった場合も弾を消す（例：画面外に出た時の壁など）
        if (other.CompareTag("Tama"))
        {
            Destroy(gameObject);
        }
    }

}
