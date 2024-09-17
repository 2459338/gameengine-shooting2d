using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform shootingPoint; // �e�̔��ˈʒu
    public float bulletSpeed = 10f; // �e�̑��x

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �e�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        // �e�ɗ͂������Ĕ���
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


        // ���̑��̃I�u�W�F�N�g�ɓ��������ꍇ���e�������i��F��ʊO�ɏo�����̕ǂȂǁj
        if (other.CompareTag("Tama"))
        {
            Destroy(gameObject);
        }
    }

}
