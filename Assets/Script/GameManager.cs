using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 5;
    public int bossHit = 0; //ボスに当たったヒット数
    public Text bossHitText;      // ボスヒット数を表示するUI Text
    public int bosshitThreshold = 20;
    public GameObject specialAttackPrefab;
    public bool canUseSpecialAttack = false;


    /// </summary>
    // Start is called before the first frame update
    private void Start()
    {
        //初期のヒット数を表示
        UpdateBossHitText();
    }
    // Update is called once per frame
    

    
   

    //プレイヤーが障害物に当たったときに呼ばれるメソッド
    
    public void BossHit(GameObject tama)
    {

        bossHit++;//ボスヒット数を増やす
        UpdateBossHitText(); //Textを更新

      

        if (bossHit >= bosshitThreshold)
        {
            SceneManager.LoadScene("BossEndScene");
        }
       
    }
    //ヒット数に基づいてTextを更新する関数
    private void UpdateBossHitText()
    {
        bossHitText.text = bossHit.ToString() + "Hit!!";
    }
    private void ChangeBulletSprite()
    {
    }
}
