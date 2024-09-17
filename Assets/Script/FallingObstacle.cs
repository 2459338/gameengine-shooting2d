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
        //��Q�������Ɉړ�������
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        //��ʊO�ɏo����폜
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        //�e�ɓ���������
        if (collision.CompareTag("Bullet"))
        {
            //��Q�����폜
            Destroy(gameObject);
        }
    }
}
