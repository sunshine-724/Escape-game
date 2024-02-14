using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*ゲームをスタートするためのボタンを押した時のスクリプト*/

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンがクリックされたらGameSceneに移動する
    public void ClickStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
