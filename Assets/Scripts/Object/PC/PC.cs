using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    [SerializeField] Player player;

    /*Canvas_UIオブジェクト*/
    public GameObject pc_Power; //PCの中身を一括管理する親オブジェクト(いわば電源)

    /*子オブジェクト*/
    //GameScene3ではdisplay0がパスワード認証画面、display1がログイン成功画面
    [SerializeField] GameObject[] display; //各画面

    /*変数*/
    int nowDisplay; //現在どのdisplayにいるか

    private void Awake()
    {
        nowDisplay = 0; //最初は0
    }

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
        //PCの中身を映す特定のゲームオブジェクトがアクティブか非アクティブかによって挙動を変える
        if (!pc_Power.activeSelf)
        {
            AppearDisplay(); //起動
        }
        else
        {
            DisappearDisplay(); //停止
        }
    }

    //もしPCの画面がついたら
    private void AppearDisplay()
    {
        pc_Power.SetActive(true); //全ての画面を表示

        //ただしdisplay0以外は非表示
        for (int k = 1; k < display.Length; k++)
        {
            display[k].SetActive(false);
        }
    }

    //もしPCの画面を消したら
    private void DisappearDisplay()
    {
        pc_Power.SetActive(false); //全ての画面を非表示
    }

    //次のディスプレイに移る
    public void MoveNextDisplay()
    {
        /*現在表示していたdisplayを非表示にして、次のdisplayを表示させる*/
        display[nowDisplay].SetActive(false);
        nowDisplay++;
        if (nowDisplay < display.Length)
        {
            display[nowDisplay].SetActive(true);
        }else if(nowDisplay == display.Length)
        {
            DisappearDisplay(); //全てのdisplayを表示したので停止させる
        }
        else
        {
            Debug.Log("エラー");
        }
    }
}
