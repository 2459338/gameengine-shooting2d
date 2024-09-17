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
    public HealthManager healthManager; // HealthManager スクリプトへの参照
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
        // カメラの幅を基に画面の境界を計算
        Camera camera = Camera.main;
        float halfScreenWidth = camera.orthographicSize * camera.aspect;
        minX = -halfScreenWidth + padding;
        maxX = halfScreenWidth - padding;
        currenHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        // 水平方向の入力を取得
        float moveInput = Input.GetAxis("Horizontal");

        // プレイヤーのポジションを変更
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0, 0);
        // プレイヤーの位置を画面内に制限
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        //障害物に当たらなかった場合のタイマーを進める
        if (!hasCollided)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                //ボスステージに移動 
                SceneManager.LoadScene(bossStageSceneName);
            }
        }
     

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //"Insei"タグの障害物に当たった場合
        if (collision.gameObject.CompareTag("Inseki"))
        {
            GameOver();
            Debug.Log("Inseki hit!");
            //障害物に当たったらタイマーリセット
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
        //"Alien"のタグの障害物に当たった場合
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
        //ダメージ処理
        currenHealth -= damage;
        //体力が０以下ならゲームオーバー
        if (currenHealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        //ゲームオーバーシーンに移動
        SceneManager.LoadScene("GameOverScene");
    }
    void UseSpecialAttack()
    {
        //必殺技を生成する
        Vector3 position = transform.position;
        Instantiate(specialAttackPrefub, position, Quaternion.identity);

        //必殺技を使用後、もう一度使えないようにフラグをリセット
        gameManager.canUseSpecialAttack = false;
        Debug.Log("Special attack used!");
    }
}
