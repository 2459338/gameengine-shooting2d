using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject explosionPrefab;  // �����̃v���t�@�u��ݒ肷��t�B�[���h

    void OnTriggerEnter2D(Collider2D other)
    {
        // �e�ɓ��������ꍇ
        if (other.CompareTag("Bullet"))
        {
            // �����̃v���t�@�u���{�X�̈ʒu�ɐ���
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // �e��j��
            Destroy(other.gameObject);

            // �K�v�Ȃ�{�X���g�̃_���[�W�����⑼�̏�����ǉ�����
            // Destroy(gameObject); // �{�X���j�󂳂��ꍇ
        }
    }
}
