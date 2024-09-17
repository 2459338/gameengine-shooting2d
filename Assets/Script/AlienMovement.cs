using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float fallSpeed = 2f; // 初期の落下速度
    public float stopDuration = 1f; // 停止する時間
    public float moveDuration = 2f; // 動く時間
    public float minYPosition = -2f; // 停止位置の最低Y座標
    public float maxYPosition = 2f; // 停止位置の最高Y座標
    private float stopYPosition; // ランダムに設定される停止位置
    private float timer = 0f; // 時間の計測
    private bool isMoving = true; // 動いているかどうかのフラグ

    void Start()
    {
        // 停止位置をランダムに設定
        stopYPosition = Random.Range(minYPosition, maxYPosition);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isMoving)
        {
            // エイリアンを下に移動させる
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // エイリアンが停止位置に到達したら停止
            if (transform.position.y <= stopYPosition)
            {
                isMoving = false;
                timer = 0f;
            }
        }
        else
        {
            // 停止中の時間を計測
            if (timer >= stopDuration)
            {
                isMoving = true;
                timer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たったとき
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        // 地面に当たったとき
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
