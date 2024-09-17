using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float fallSpeed = 2f; // �����̗������x
    public float stopDuration = 1f; // ��~���鎞��
    public float moveDuration = 2f; // ��������
    public float minYPosition = -2f; // ��~�ʒu�̍Œ�Y���W
    public float maxYPosition = 2f; // ��~�ʒu�̍ō�Y���W
    private float stopYPosition; // �����_���ɐݒ肳����~�ʒu
    private float timer = 0f; // ���Ԃ̌v��
    private bool isMoving = true; // �����Ă��邩�ǂ����̃t���O

    void Start()
    {
        // ��~�ʒu�������_���ɐݒ�
        stopYPosition = Random.Range(minYPosition, maxYPosition);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isMoving)
        {
            // �G�C���A�������Ɉړ�������
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // �G�C���A������~�ʒu�ɓ��B�������~
            if (transform.position.y <= stopYPosition)
            {
                isMoving = false;
                timer = 0f;
            }
        }
        else
        {
            // ��~���̎��Ԃ��v��
            if (timer >= stopDuration)
            {
                isMoving = true;
                timer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[�ɓ��������Ƃ�
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        // �n�ʂɓ��������Ƃ�
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
