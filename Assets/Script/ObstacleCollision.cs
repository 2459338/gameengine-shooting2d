using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public float offScreenY = -6f; // ��ʊO��Y���W�i�������K�v�j

    void Update()
    {
        // ��ʊO�ɏo���Ƃ�
        if (transform.position.y < offScreenY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[�ɓ��������Ƃ�
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
