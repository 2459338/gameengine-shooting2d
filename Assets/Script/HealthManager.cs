using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hearts; // ハートのUIオブジェクトを格納する配列
    public Sprite fullHeart; // 色付きのハートのスプライト
    public Sprite emptyHeart; // 白黒のハートのスプライト
    private int health; // 現在の体力
    private int maxHealth = 5; // 最大体力

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
