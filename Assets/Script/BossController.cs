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
    private bool movingRight = true; // �E�Ɉړ������ǂ����̃t���O
    public GameObject explosionprefub; //�����G�t�F�N�g�̃v���t�@�u

    // Start is called before the first frame update
    void Start()
    {
        //�{�X���V�[���ɓo�ꂷ��Ƃ��̏����ݒ�
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
        // �{�X���E�Ɉړ����̏ꍇ
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            // �E�[�ɓ��B�����������ς���
            if (transform.position.x >= rigthBoundary)
            {
                movingRight = false;
            }
        }
        // �{�X�����Ɉړ����̏ꍇ
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // ���[�ɓ��B�����������ς���
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
                // �����G�t�F�N�g��e�����������ʒu�ɐ���
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
