using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public float fallSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //障害物を下に移動させる
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        //画面外に出たら削除
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        //弾に当たったら
        if (collision.CompareTag("Bullet"))
        {
            //障害物を削除
            Destroy(gameObject);
        }
    }
}
