using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 5;
    public int bossHit = 0; //�{�X�ɓ��������q�b�g��
    public Text bossHitText;      // �{�X�q�b�g����\������UI Text
    public int bosshitThreshold = 20;
    public GameObject specialAttackPrefab;
    public bool canUseSpecialAttack = false;


    /// </summary>
    // Start is called before the first frame update
    private void Start()
    {
        //�����̃q�b�g����\��
        UpdateBossHitText();
    }
    // Update is called once per frame
    

    
   

    //�v���C���[����Q���ɓ��������Ƃ��ɌĂ΂�郁�\�b�h
    
    public void BossHit(GameObject tama)
    {

        bossHit++;//�{�X�q�b�g���𑝂₷
        UpdateBossHitText(); //Text���X�V

      

        if (bossHit >= bosshitThreshold)
        {
            SceneManager.LoadScene("BossEndScene");
        }
       
    }
    //�q�b�g���Ɋ�Â���Text���X�V����֐�
    private void UpdateBossHitText()
    {
        bossHitText.text = bossHit.ToString() + "Hit!!";
    }
    private void ChangeBulletSprite()
    {
    }
}
