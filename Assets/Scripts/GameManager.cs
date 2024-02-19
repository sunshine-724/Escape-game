using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*テキストを出したいオブジェクトにアタッチする*/
public class GameManager : MonoBehaviour
{
    /*変数宣言(これらのプロパティはシーンを跨いでも保持させる)*/
    [System.NonSerialized] public static bool[] isEvents; //各イベントを開始しても良いか
    private static int eventNumbers = 10; //イベントの数(とりあえず今は10にする(あとで調整可)

    private void Start()
    {
        isEvents = new bool[eventNumbers];

        for(int k = 0; k < eventNumbers; k++)
        {
            isEvents[k] = false; //動的に全てのフラグをfalseにする
        }

        isEvents[0] = true; //ただし、このStartメソッドが動いている時点で最初のゲームシーンのロードは終わっているから始めだけtrueにする
    }

    private void Update()
    {
        
    }

    //今どのイベントを実行中かをDebug.Logで出力させる
    public static void NowEvent()
    {
        int k; //カウンタ変数

        for(k = 0; k < eventNumbers; k++)
        {
            if (isEvents[k] == true)
            {
                continue;
            }
            else
            {
                break;
            }
        }

        Debug.Log("現在実行中のイベントは" + (k-1) + "です");
    }
}


