using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    void Update()
    {
        //下方向に動かす
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-19.17まで下がったら、19.17まで戻す
        if (transform.position.y <= -17.17f)
        {
            transform.position = new Vector2(0, 17.17f);
        }
    }
}
