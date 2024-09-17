using UnityEngine;

public class Tama : MonoBehaviour
{
    public GameObject hitEffectPrefub2;
    public float bulletSpeed = 10f;
    private bool hasShot = false;
    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasShot)
        {
            //弾を上方向に移動させる
            GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
            hasShot = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // "Boss" タグを持つオブジェクトに当たったら
        if (collision.gameObject.CompareTag("Boss"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.BossHit(collision.gameObject);
            // ボスにヒットエフェクトなどを追加したい場合はここに書く
            Debug.Log("弾がボスに当たった");

            //エフェクトを表示
            ShowHitEffect();
            // 弾を削除する
            Destroy(gameObject);
        }
    }
    void ShowHitEffect()
    {
        //エフェクトを生成
        GameObject effect = Instantiate(hitEffectPrefub2, transform.position, Quaternion.identity);
        //エフェクトを二秒後に削除
        Destroy(effect, 5f);
    }
    private void OnBecameInvisible()
    {
        //弾が画面外に出たら破壊する
        Destroy(gameObject);
    }
}
