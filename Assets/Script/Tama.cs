using UnityEngine;

public class Tama : MonoBehaviour
{
    public GameObject hitEffectPrefub2;
    public float bulletSpeed = 10f;
    private bool hasShot = false;
    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasShot)
        {
            //�e��������Ɉړ�������
            GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
            hasShot = true;
        }
    }
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
        GameObject effect = Instantiate(hitEffectPrefub2, transform.position, Quaternion.identity);
        //�G�t�F�N�g���b��ɍ폜
        Destroy(effect, 5f);
    }
    private void OnBecameInvisible()
    {
        //�e����ʊO�ɏo����j�󂷂�
        Destroy(gameObject);
    }
}
