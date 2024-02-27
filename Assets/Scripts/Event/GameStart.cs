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

    //ボタンがクリックされたらGameScene1に移動する
    public void ClickStart()
    {
        SceneManager.LoadScene("GameScene1");
    }

    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了(エディターでプレイ時)
#else
        Application.Quit();//ゲームプレイ終了(ビルドでプレイ時)
#endif
    }
}
