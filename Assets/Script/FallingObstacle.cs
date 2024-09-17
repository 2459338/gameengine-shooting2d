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
        //áŠQ•¨‚ğ‰º‚ÉˆÚ“®‚³‚¹‚é
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        //‰æ–ÊŠO‚Éo‚½‚çíœ
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        //’e‚É“–‚½‚Á‚½‚ç
        if (collision.CompareTag("Bullet"))
        {
            //áŠQ•¨‚ğíœ
            Destroy(gameObject);
        }
    }
}
