using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int EventNumber;//今何番目のイベントかをインスペクタで書く(最終イベント（Endingは10にする)

    //イベント１関連
    [SerializeField] Event1_1Manager event1_1Manager;
    [SerializeField] Event1_2Manager event1_2Manager;
    [SerializeField] Event1_3Manager event1_3Manager;
    [SerializeField] Event1_4Manager event1_4Manager;

    //イベント2関連
    [SerializeField] Event2_1Manager event2_1Manager;

    //イベント3関連
    [SerializeField] Event3_1Manager event3_1Manager;
    [SerializeField] Event3_2Manager event3_2Manager;

    //イベント4関連
    [SerializeField] Event4_1Manager event4_1Manager;

    //イベント10関連
    [SerializeField] Event10_1Manager event10_1Manager;

    [SerializeField] Ending ending; //エンディングを管理するクラス
    [SerializeField] Enemy enemy; //敵キャラ

    //bgm
    [SerializeField] GameObject soundBox_Bgm;

    [SerializeField] Player player;

    [SerializeField] CanvasEvent0 canvasEvent0;
    [SerializeField] GameObject CanvasEvent1;

    //変数宣言
    private bool nextEvent = false; //次のイベントを開始しても良いか(大きなイベントで）

    bool event10StartFlag = true; //イベント10を始めても良いか

    [SerializeField] float ChangeScenePlayerXPositon; //プレイヤーがこのX座標より右に行ったらシーンを切り替える(シーン毎に数値が異なる)


    private void Awake()
    {
        //どのゲームマネージャーかで実行する内容を変える
        switch (EventNumber)
        {
            case 0:
                break;

            case 3:
                event3_1Manager.Starting1();
                break;
            case 4:
                event4_1Manager.Starting1();
                break;

            case 10:
                event10_1Manager.Starting1();
                break;

            default:
                Debug.Log("そのようなイベントは存在しません");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //どのゲームマネージャーかで実行する内容を変える
        switch (EventNumber)
        {
            case 0:
                player.IsMove(false); //最初はプレイヤーを動かせないようにする
                StartCoroutine(canvasEvent0.Starting1());
                break;

            case 3:
                break;

            default:
                Debug.Log("そのようなイベントは存在しません");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Zキーが押されたら
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (EventNumber)
            {
                case 0:
                    Update_Event0_InputZKey();
                    break;

                case 1:
                    Update_Event1_InputZKey();
                    break;
                case 10:
                    Update_Event10_InputZKey();
                    break;
                default:
                    break;
            }
        }

        switch (EventNumber)
        {
            case 0:
                UpdateEvent0_AllTheTime();
                break;

            case 1:
                UpdateEvent1_AllTheTime();
                break;

            case 2:
                UpdateEvent2_AllTheTime();
                break;

            case 3:
                UpdateEvent3_AllTheTime();
                break;

            case 4:
                UpdateEvent4_AllTheTime();
                break;

            case 10:
                UpdateEvent10_AllTheTime();
                break;

            default:
                break;
        }

        if (nextEvent)
        {
            nextEvent = false; //連続して次のイベントに行かないようにする
            NextEvent(); //次のイベントに移る
        }
    }

    void NextEvent()
    {
        EventNumber++;

        switch (EventNumber)
        {
            case 1:
                StartCoroutine(event1_1Manager.Starting1());
                break;

            case 2:
                soundBox_Bgm.SetActive(false); //bgmをオフにする
                break;

            case 5:
                //フェードアウト実行後
                SceneManager.LoadScene("Ending"); //次のシーンに移る
                break;

            default:
                Debug.Log("エラー");
                break;
        }
    }

    /*UpdateメソッドでZキーが押されている間、常に呼び出されるメソッド*/
    void Update_Event0_InputZKey()
    {
        /*イベント0関連*/
        if ((!canvasEvent0.isEnd) && (!canvasEvent0.nowMethod))
        {
            switch (canvasEvent0.nowEvent)
            {
                case 2:
                    soundBox_Bgm.SetActive(true); //bgmをオンにする
                    StartCoroutine(canvasEvent0.Starting2());
                    break;

                case 3:
                    StartCoroutine(canvasEvent0.Ending());
                    break;

                default:
                    Debug.Log("エラー");
                    break;
            }
        }
    }

    void Update_Event1_InputZKey()
    {
        /*イベント1関連*/
        if ((!event1_1Manager.isEnd) && (!event1_1Manager.nowMethod))
        {
            switch (event1_1Manager.nowEvent)
            {
                case 2:
                    StartCoroutine(event1_1Manager.Starting2());
                    break;

                case 3:
                    StartCoroutine(event1_1Manager.Ending());
                    break;

                default:
                    Debug.Log("エラー");
                    break;
            }
        }
        else if ((!event1_2Manager.isEnd) && (!event1_2Manager.nowMethod))
        {
            Debug.Log(event1_2Manager.nowEvent + "が実行されます");
            switch (event1_2Manager.nowEvent)
            {
                case 2:
                    StartCoroutine(event1_2Manager.Starting2());
                    break;

                case 3:
                    StartCoroutine(event1_2Manager.Starting3());
                    break;

                case 4:
                    StartCoroutine(event1_2Manager.Ending());
                    break;

                default:
                    Debug.Log("エラー");
                    break;
            }
        }
        else if ((!event1_3Manager.isEnd) && (!event1_3Manager.nowMethod))
        {
            Debug.Log(event1_3Manager.nowEvent + "が実行されます");
            switch (event1_3Manager.nowEvent)
            {
                case 2:
                    StartCoroutine(event1_3Manager.Starting2());
                    break;
                case 3:
                    StartCoroutine(event1_3Manager.Starting3());
                    break;

                case 4:
                    StartCoroutine(event1_3Manager.Ending());
                    break;

                default:
                    Debug.Log("エラー");
                    break;
            }
        }
        else if ((!event1_4Manager.isEnd) && (!event1_4Manager.nowMethod))
        {
            Debug.Log(event1_4Manager.nowEvent + "が実行されます");
            switch (event1_4Manager.nowEvent)
            {
                case 2:
                    StartCoroutine(event1_4Manager.Ending());
                    break;
                default:
                    Debug.Log("エラー");
                    break;
            }
        }
    }

    void Update_Event10_InputZKey()
    {
        ending.InputZkey();
    }

    /*Updateメソッドで常に呼び出されるメソッド*/
    void UpdateEvent0_AllTheTime()
    {
        //もし各イベント0が終了してかつコルーチンが実行されていなかったら
        if ((canvasEvent0.isEnd) && (!canvasEvent0.nowMethod))
        {
            canvasEvent0.nowMethod = true; //このイベントのメソッドをこれ以上実行されないようにする
            Debug.Log("次のイベントに移ります");
            nextEvent = true;
        }
    }

    void UpdateEvent1_AllTheTime()
    {
        //もし各イベント1が終了してかつコルーチンが実行されていなかったら
        if ((event1_1Manager.isEnd) && (!event1_1Manager.nowMethod))
        {
            StartCoroutine(event1_2Manager.Starting1());
            event1_1Manager.nowMethod = true; //このイベントのメソッドをこれ以上実行されないようにする
        }
        else if ((event1_2Manager.isEnd) && (!event1_2Manager.nowMethod))
        {
            StartCoroutine(event1_3Manager.Starting1());
            event1_2Manager.nowMethod = true;
        }
        else if ((event1_3Manager.isEnd) && (!event1_3Manager.nowMethod))
        {
            StartCoroutine(event1_4Manager.Starting1());
            event1_3Manager.nowMethod = true;
        }
        else if ((event1_4Manager.isEnd) && (!event1_4Manager.nowMethod))
        {
            event1_4Manager.nowMethod = true;
            CanvasEvent1.SetActive(false); //関連するもの全てfalse

            player.IsMove(true); //プレイヤーが動けるようにする
            player.isLeftMove = false; //ただし、左にはいけないようにする
            Debug.Log("イベント1終了");
            nextEvent = true; //次のイベントにいける許可を与える
        }
    }

    void UpdateEvent2_AllTheTime()
    {
        if((player.pos.x >= ChangeScenePlayerXPositon) && (!event2_1Manager.nowMethod))
        {
            event2_1Manager.nowMethod = true; //連続で条件を満たさないようにする
            StartCoroutine(event2_1Manager.Starting1());
        }

        if (event2_1Manager.isEnd)
        {
            SceneManager.LoadScene("GameScene2"); //次のシーンに移る
        }
    }

    void UpdateEvent3_AllTheTime()
    {
        if ((event3_1Manager.isEnd) &&　(player.pos.x >=ChangeScenePlayerXPositon))
        {
            StartCoroutine(event3_2Manager.Starting1()); //ワイプを実行
        }

        if (event3_2Manager.isEnd)
        {
            SceneManager.LoadScene("GameScene3"); //次のシーンに移る
        }
    }

    void UpdateEvent4_AllTheTime()
    {
        
    }

    void UpdateEvent10_AllTheTime()
    {
        if ((EventNumber == 10) && (player.pos.x >= ChangeScenePlayerXPositon) && (event10StartFlag))
        {
            player.pos.x = ChangeScenePlayerXPositon + 0.5f;
            event10StartFlag = false;
            player.IsMove(false); //プレイヤーを止める
            ending.EndingManager(); //エンディング開始
        }
    }

    //特定のイベントマネージャーから通知が来たら値によって指定したメソッドを起動する
    public void Notification(int number)
    {
        switch (number)
        {
            case 0:
                StartCoroutine(event4_1Manager.Starting2());
                break;

            case 1:
                nextEvent = true; //次のイベント（シーンに移る)
                break;

            default:
                Debug.Log("そのような通知は存在しません");
                break;
        }
    }
}


