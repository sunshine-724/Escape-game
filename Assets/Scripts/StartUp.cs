using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンがクリックされたらゲーム画面に移行する
    private void ClickStart()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("スタートボタンが押されたのでゲーム画面に移行しました");
    }
}
