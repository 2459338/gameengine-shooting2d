using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public float speed = 5f;
    public float padding = 0.5f;
    private float minX, maxX;
    public HealthManager healthManager; // HealthManager �X�N���v�g�ւ̎Q��
    public int maxHealth = 5;
    private int currenHealth;
    public float timeToWait = 20f;
    public string bossStageSceneName = "BossScene";
    private float timer = 0;
    private bool hasCollided = false;
    public GameManager gameManager;
    public GameObject specialAttackPrefub;

    // Start is called before the first frame update
    void Start()
    {
        // �J�����̕�����ɉ�ʂ̋��E���v�Z
        Camera camera = Camera.main;
        float halfScreenWidth = camera.orthographicSize * camera.aspect;
        minX = -halfScreenWidth + padding;
        maxX = halfScreenWidth - padding;
        currenHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        // ���������̓��͂��擾
        float moveInput = Input.GetAxis("Horizontal");

        // �v���C���[�̃|�W�V������ύX
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
        // �v���C���[�̈ʒu����ʓ��ɐ���
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        //��Q���ɓ�����Ȃ������ꍇ�̃^�C�}�[��i�߂�
        if (!hasCollided)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                //�{�X�X�e�[�W�Ɉړ� 
                SceneManager.LoadScene(bossStageSceneName);
            }
        }
     

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //"Insei"�^�O�̏�Q���ɓ��������ꍇ
        if (collision.gameObject.CompareTag("Inseki"))
        {
            GameOver();
            Debug.Log("Inseki hit!");
            //��Q���ɓ���������^�C�}�[���Z�b�g
            if (hasCollided)
            {
                timer = 0;
                hasCollided = false;
               
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= timeToWait)
                {
                    GameOver();
                }
            }
          
        }
        //"Alien"�̃^�O�̏�Q���ɓ��������ꍇ
        else if (collision.gameObject.CompareTag("Alien"))
        {
            Debug.Log("Alien hit!");
            if (hasCollided)
            {
                timer = 0;
                hasCollided = false;
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= timeToWait)
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
           
            healthManager.TakeDamage(1);
        }
    }
    void TakeDamage(int damage)
    {
        //�_���[�W����
        currenHealth -= damage;
        //�̗͂��O�ȉ��Ȃ�Q�[���I�[�o�[
        if (currenHealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        //�Q�[���I�[�o�[�V�[���Ɉړ�
        SceneManager.LoadScene("GameOverScene");
    }
    void UseSpecialAttack()
    {
        //�K�E�Z�𐶐�����
        Vector3 position = transform.position;
        Instantiate(specialAttackPrefub, position, Quaternion.identity);

        //�K�E�Z���g�p��A������x�g���Ȃ��悤�Ƀt���O�����Z�b�g
        gameManager.canUseSpecialAttack = false;
        Debug.Log("Special attack used!");
    }
}
