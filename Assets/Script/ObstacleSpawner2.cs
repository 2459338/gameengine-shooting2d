using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    public GameObject obstaclePrefab; // 障害物のプレハブ
    public Vector2 spawnRangeX=new Vector2(-5f,5f); // X軸の生成範囲
    public float spawnInterval = 2f; // 生成間隔
    private float timer;
    public float fallSpeed = 5f;
   
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }
     void Update()
    {
        //タイマーを増加させる
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;//タイマーをリセット
        }
    }


    void SpawnObstacle()
    {
        // ランダムなX座標を取得
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);

        // 生成位置を設定
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        // 障害物を生成
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // 障害物に落下速度を適用する
        obstacle.GetComponent<ObstacleFall>().fallSpeed = fallSpeed;
    }

}
