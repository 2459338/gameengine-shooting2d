using UnityEngine;
using TMPro; // TextMeshPro 用

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMeshProUGUI を使う

    public float timeToWait = 20f;
    private float timer = 0f;
    private bool hasCollided = false;

    void Update()
    {
        if (hasCollided)
        {
            timer = 0f;
            hasCollided = false;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                // ゲームオーバーシーンに移動
                // SceneManager.LoadScene("GameOverScene");
            }
        }

        // タイマー表示
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Max(0, timeToWait - timer).ToString("F2");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            hasCollided = true;
        }
    }
}
