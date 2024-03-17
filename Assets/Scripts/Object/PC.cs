using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] GameObject pc_Input;
    [SerializeField] GameObject Image_LoginSuccessful; //ログイン成功画面



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*PCと接触していてかつZキーを押されたらオブジェクトの状態によってメソッドを実行する*/
    public void checkStatus()
    {
        //ポスターの中身を映すキャンバスがアクティブか非アクティブかによって挙動を変える
        if (!pc_Input.activeSelf)
        {
            AppearPaper();
        }
        else if (pc_Input.activeSelf)
        {
            DisappearPaper();
        }

        //もしログイン成功画面が表示されていたら
        if (Image_LoginSuccessful.activeSelf)
        {
            DisappearImage_Login();
        }
    }

    private void AppearPaper()
    {
        player.IsMove(false); //プレイヤーが動けないようにする

        pc_Input.SetActive(true); //ポスターの中身を出現させる
        Image_LoginSuccessful.SetActive(true); //ただし子オブジェクトであるログイン画面は非表示にする
    }

    private void DisappearPaper()
    {
        pc_Input.SetActive(false); //ポスターの中身を閉じる
        Image_LoginSuccessful.SetActive(true); //ログイン成功画面を表示
    }

    private void DisappearImage_Login()
    {
        Image_LoginSuccessful.SetActive(false); //ログイン成功画面を閉じる
        pc_Input.SetActive(false); //PC画面にまつわる全てのオブジェクトを非アクティブにする
        player.IsMove(true); //プレイヤーを再度動けるようにする
    }
}
