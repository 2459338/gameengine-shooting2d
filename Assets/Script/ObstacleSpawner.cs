using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 覐΂̃v���n�u
    public float spawnInterval = 1f;  // �����Ԋu
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        // �J�����̍��[�ƉE�[�����[���h���W�Ŏ擾
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // 覐΂̐����ʒu������i��ʓ��͈̔͂Ɍ���j
        float spawnX = Random.Range(screenLeft, screenRight);
        Vector3 spawnPosition = new Vector3(spawnX, 6f, 0f); // �����ʒu��Y���W��ݒ�

        // 覐΂𐶐�
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
