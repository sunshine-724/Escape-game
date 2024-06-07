using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*ゲームをスタートするためのボタンの挙動をまとめたスクリプト*/

public class GameStart : MonoBehaviour
{
    [SerializeField] GameObject storyObject; //ストーリーを説明する際に必要なオブジェクトをまとめた親オブジェクト
    [SerializeField] GameObject storyButton; //STORYボタン

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //StartボタンがクリックされたらGameScene1に移動する
    public void ClickStart()
    {
        SceneManager.LoadScene("GameScene1");
    }

    //Returnボタンがクリックされたらゲームをやめる
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了(エディターでプレイ時)
#else
        Application.Quit();//ゲームプレイ終了(ビルドでプレイ時)
#endif
    }

    //Storyボタンがクリックされたら説明画面を表示し、再度クリックされたら閉じる
    public void ExplainStory()
    {
        if (storyObject.activeSelf)
        {
            storyButton.SetActive(true); //STORYボタンが反応できるようにする
            storyObject.SetActive(false);
        }
        else
        {
            storyObject.SetActive(true);
            storyButton.SetActive(false); //一時的にSTORYボタンが反応できないようにする
        }
    }
}
