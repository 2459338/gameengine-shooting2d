using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    public GameObject obstaclePrefab; // ��Q���̃v���n�u
    public Vector2 spawnRangeX=new Vector2(-5f,5f); // X���̐����͈�
    public float spawnInterval = 2f; // �����Ԋu
    private float timer;
    public float fallSpeed = 5f;
   
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }
     void Update()
    {
        //�^�C�}�[�𑝉�������
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;//�^�C�}�[�����Z�b�g
        }
    }


    void SpawnObstacle()
    {
        // �����_����X���W���擾
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);

        // �����ʒu��ݒ�
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        // ��Q���𐶐�
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // ��Q���ɗ������x��K�p����
        obstacle.GetComponent<ObstacleFall>().fallSpeed = fallSpeed;
    }

}
