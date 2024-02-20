using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    /*変数宣言(これらのプロパティはシーンを跨いでも保持させる)*/
    private bool[] isEvents = new bool[10]; //各イベントを開始しても良いか((とりあえず今は10にする(あとで調整可))


    private void Awake()
    {
        for (int k = 0; k < 10; k++)
        {
            isEvents[k] = false; //動的に全てのフラグをfalseにする
        }
    }
    private void Start()
    { 
        isEvents[0] = true; //ただし、このStartメソッドが動いている時点で最初のゲームシーンのロードは終わっているから始めだけtrueにする
    }

    private void Update()
    {
       
    }

    //イベントの許可を更新する
    public void UpdateEvent(int k)
    {
        if (k <= 0)
        {
            Debug.Log("イベントの進行にエラーが生じています");
        }
        else
        {
            isEvents[k - 1] = false; //終了したイベントはfalseにする
            isEvents[k] = true;
            Debug.Log("イベント" + k + "の開始許可が下りました");
        }

    }

    //指定されたイベントを開始しても良いかyes,noで返す
    public bool CheckEvent(int k)
    {
        if (isEvents[k] == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //今どのイベントを実行中かをDebug.Logで出力させる
    public void NowEvent()
    {
        int k; //カウンタ変数

        for(k = 0; k < 10; k++)
        {
            if (isEvents[k] == true)
            {
                break;
            }
        }

        Debug.Log("現在実行中のイベントは" + (k) + "です");
    }
}


