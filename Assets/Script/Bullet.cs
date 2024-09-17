using UnityEngine;

public class Bleet : MonoBehaviour
{
    public GameObject hitEffectPrefub;
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
        GameObject effect = Instantiate(hitEffectPrefub, transform.position, Quaternion.identity);
        //エフェクトを二秒後に削除
        Destroy(effect, 0.5f);
    }
}
