using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 1;

    void Update()
    {
        //�������ɓ�����
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Y��-19.17�܂ŉ���������A19.17�܂Ŗ߂�
        if (transform.position.y <= -17.17f)
        {
            transform.position = new Vector2(0, 17.17f);
        }
    }
}
