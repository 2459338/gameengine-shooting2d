using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed=2f;
    public float leftBoundary = -5f;
    public float rigthBoundary = 5f;
    private bool movingRight = true; // 右に移動中かどうかのフラグ
    public GameObject explosionprefub; //爆発エフェクトのプレファブ

    // Start is called before the first frame update
    void Start()
    {
        //ボスがシーンに登場するときの初期設定
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameClearScene");
    }
    void Move()
    {
        // ボスが右に移動中の場合
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            // 右端に到達したら方向を変える
            if (transform.position.x >= rigthBoundary)
            {
                movingRight = false;
            }
        }
        // ボスが左に移動中の場合
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // 左端に到達したら方向を変える
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tama"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                Debug.Log("GameManager found.");
                gameManager.BossHit(collision.gameObject);
            }
            else
            {
                Debug.LogError("GameManager not found!");
            }
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Debug.Log("Boss hitBullet!");
                // 爆発エフェクトを弾が当たった位置に生成
                Instantiate(explosionprefub, transform.position, transform.rotation);

            }

            if (explosionprefub != null)
            {
                Debug.Log("Explosion prefab instantiated!");
                Instantiate(explosionprefub, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Explosion prefab is not assigned!");
            }


        }
        }
    
}
