using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleFall : MonoBehaviour
{
    public float fallSpeed = 2f; // 落下速度
    public float offScreenY = -10f; // 画面外のY座標

    void Update()
    {
        // 隕石を下に移動させる
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // 画面外に出たとき
        if (transform.position.y < offScreenY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーに当たったとき
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
