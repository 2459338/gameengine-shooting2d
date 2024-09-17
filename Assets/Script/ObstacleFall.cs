using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleFall : MonoBehaviour
{
    public float fallSpeed = 2f; // �������x
    public float offScreenY = -10f; // ��ʊO��Y���W

    void Update()
    {
        // 覐΂����Ɉړ�������
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

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
            SceneManager.LoadScene("GameOverScene");
        }
        if (other.CompareTag("Tama")) {
            Destroy(gameObject);
        }
    }
   
}
