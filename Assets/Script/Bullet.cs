using UnityEngine;

public class Bleet : MonoBehaviour
{
    public GameObject hitEffectPrefub;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // "Boss" �^�O�����I�u�W�F�N�g�ɓ���������
        if (collision.gameObject.CompareTag("Boss"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.BossHit(collision.gameObject);
            // �{�X�Ƀq�b�g�G�t�F�N�g�Ȃǂ�ǉ��������ꍇ�͂����ɏ���
            Debug.Log("�e���{�X�ɓ�������");

            //�G�t�F�N�g��\��
            ShowHitEffect();
            // �e���폜����
            Destroy(gameObject);
        }
    }
    void ShowHitEffect()
    {
        //�G�t�F�N�g�𐶐�
        GameObject effect = Instantiate(hitEffectPrefub, transform.position, Quaternion.identity);
        //�G�t�F�N�g���b��ɍ폜
        Destroy(effect, 0.5f);
    }
}
