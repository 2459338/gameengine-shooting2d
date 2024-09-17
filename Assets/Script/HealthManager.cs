using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts; // �n�[�g��UI�I�u�W�F�N�g���i�[����z��
    public Sprite fullHeart; // �F�t���̃n�[�g�̃X�v���C�g
    public Sprite emptyHeart; // �����̃n�[�g�̃X�v���C�g
    private int health; // ���݂̗̑�
    private int maxHealth = 5; // �ő�̗�

    void Start()
    {
        health = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
                Debug.Log("Heart" + i+"is full.");
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                Debug.Log("Heart" + i + "is empty");
            }
        }
    }
}
