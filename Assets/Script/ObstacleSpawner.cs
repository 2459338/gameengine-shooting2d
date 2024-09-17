using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // 隕石のプレハブ
    public float spawnInterval = 1f;  // 生成間隔
    private float screenLeft;
    private float screenRight;

    void Start()
    {
        // カメラの左端と右端をワールド座標で取得
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // 隕石の生成位置を決定（画面内の範囲に限定）
        float spawnX = Random.Range(screenLeft, screenRight);
        Vector3 spawnPosition = new Vector3(spawnX, 6f, 0f); // 生成位置のY座標を設定

        // 隕石を生成
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
