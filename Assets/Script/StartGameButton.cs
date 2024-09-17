using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void StartGame()
    {
        //ゲームプレイシーンに移動
        SceneManager.LoadScene("GameScene");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("GameStartScene");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
