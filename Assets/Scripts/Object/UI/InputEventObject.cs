using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventObject : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject OutputPaper;

    [SerializeField] MoveText moveText; //スマートフォンに表示させるテキスト集

    public bool isPlayer { get; private set; } //プレイヤーと接触しているかどうかを確認するフラグ

    private void Awake()
    {
        isPlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void checkStatus()
    {
            //ポスターの中身を映すキャンバスがアクティブか非アクティブかによって挙動を変える
            if (!OutputPaper.activeSelf)
            {
                AppearPaper();
            }
            else if (OutputPaper.activeSelf)
            {
                DisappearPaper();
            }
    }

    private void AppearPaper()
    {
        player.IsMove(false); //プレイヤーが動けないようにする
        OutputPaper.SetActive(true); //ポスターの中身を出現させる
    }

    private void DisappearPaper()
    {
        player.IsMove(true); //プレイヤーが動けるようにする
        OutputPaper.SetActive(false); //ポスターの中身を閉じる
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            isPlayer = false;
        }
    }

    //プレイヤーからZキーを受け取ったらステータスを確認する
    public void ZKeyNotification()
    {
        if (isPlayer)
        {
            checkStatus();
        }
    }


    /*スマートフォン関連*/
    //もし下矢印が押された場合
    public void DownKeyNotification()
    {
        if (moveText && OutputPaper)
        {
            moveText.MoveDown();
        }
    }

    //もし上矢印が押された場合
    public void UpKeyNotification()
    {
        if(moveText && OutputPaper)
        {
            moveText.MoveUp();
        }
    }
}
