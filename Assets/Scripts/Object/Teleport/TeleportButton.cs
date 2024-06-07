using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton :MonoBehaviour
{
    public bool isButton { get;private set; } //ボタンを押したら反応してもよいか

    [SerializeField] int buttonNumber; //各ボタンを識別できる番号(0~)

    [SerializeField] Player player;
    [SerializeField] TeleportObject changeTeleportObject; //変更したいオブジェクトを選択する

    [SerializeField] string[] changeCycle; //色を変える順番をインスペクタで番号で文字で指定する
    string changeName; //変えたい色の文字列を指定する

    int changeNumber; //今何番目の色を指定されているかを表す

    private void Awake()
    {
        isButton = false;  //初期状態はfalse
        changeNumber = 0; //初期状態は0
    }
    // Start is called before the first frame update
    void Start()
    {
        if(changeCycle != null)
        {
            changeName = changeCycle[changeNumber]; //最初の色を代入する
        }
        else
        {
            Debug.Log("ボタンに色が指定されていません");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //もしプレイヤーと触れたら
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player.gameObject)
        {
            Debug.Log("ボタンに触れました");
            isButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Debug.Log("ボタンから離れました");
            isButton = false;
        }
    }

    //テレポーターの色を変える
    public void ChangeColor()
    {
        changeTeleportObject.ChangeObject(changeName);
        Change(); //次の色に変える
    }

    //変える色を再指定する
    private void Change()
    {
        if (changeNumber+1 < changeCycle.Length)
        {
            changeNumber++;
        }
        else
        {
            changeNumber = 0; //最後のサイクルまで行ったのでもう一回0から繰り返させる
        }

        changeName = changeCycle[changeNumber];
    }

}
