using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //z�L�[�������ꂽ�Ƃ��ɃQ�[���v���C�V�[���Ɉړ�
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Game Scene");
        }
    }
}
