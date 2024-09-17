using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���t�@�u
    public Transform shootingPoint; // �e�𔭎˂���ʒu
    public float bulletSpeed = 10f;

    private bool hasFired = false; // ���łɒe�𔭎˂�������ǐ�

    void Update()
    {
        // �X�y�[�X�L�[�Œe�𔭎ˁi�܂����˂��Ă��Ȃ��ꍇ�̂݁j
        if (Input.GetKeyDown(KeyCode.Space) && !hasFired)
        {
            FireBullet();
            shoot();
            hasFired = true; // ��x���˂����炱��ȏ㔭�˂��Ȃ�
        }
    }

    void FireBullet()
    {
      
    }
    void shoot()
    {
        // �e�𔭎ˈʒu�ɐ���
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }
}
