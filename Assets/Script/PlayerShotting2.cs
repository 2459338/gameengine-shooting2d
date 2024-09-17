using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレファブ
    public Transform shootingPoint; // 弾を発射する位置
    public float bulletSpeed = 10f;

    private bool hasFired = false; // すでに弾を発射したかを追跡

    void Update()
    {
        // スペースキーで弾を発射（まだ発射していない場合のみ）
        if (Input.GetKeyDown(KeyCode.Space) && !hasFired)
        {
            FireBullet();
            shoot();
            hasFired = true; // 一度発射したらこれ以上発射しない
        }
    }

    void FireBullet()
    {
      
    }
    void shoot()
    {
        // 弾を発射位置に生成
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }
}
