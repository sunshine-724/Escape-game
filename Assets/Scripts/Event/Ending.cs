using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] Telop telop; //テロップ背景
    [SerializeField] List<GameObject> text; //各テキストオブジェクト（アクティブか非アクティブかで表示するテキストを切り替える)
    [SerializeField] List<Appeartext> appeartext; //各テキストを出現するためのクラス

    [SerializeField] Player player; //プレイヤー
    [SerializeField] Enemy enemy; //敵キャラ（研究員のクラス）

    private int eventNumber; //今どのイベントかを示す
    public bool isMethod; //今メソッドを実行中（コルーチンを実行中）であるかどうか
    [SerializeField] float EndPositonx; //フェードアウトし終了する時のプレイヤーの座標
    [SerializeField] FadeOut Image_Fadeout; //フェードアウトする時の画像

    private void Awake()
    {
        eventNumber = 0; //最初は0

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((eventNumber == appeartext.Count + 1) && (player.pos.x >= EndPositonx)){
            Debug.Log("実行中");
            Image_Fadeout.Fade(); //画面をフェードアウトする
        }
    }

    public void EndingManager()
    {
        if (0 <= eventNumber && eventNumber < appeartext.Count)
        {
            StartCoroutine(StartEndingText());
        }
        else if (eventNumber == appeartext.Count)
        {
            //もし用意した全てのテキストを出力したら、研究員を左側に移動させる
            isMethod = true;
            text[eventNumber - 1].SetActive(false);
            telop.gameObject.SetActive(false);
            enemy.isLeftMove = true; //敵キャラを左側へと移動させる
        }
        else if(eventNumber == appeartext.Count+1)
        {
            player.IsMove(true);
            enemy.gameObject.SetActive(false);
        }
    }

    private IEnumerator StartEndingText()
    {
        int k; //カウンタ変数

        //もし用意した全てのテキストを出力したら、研究員を左側に移動させる
        if(eventNumber == appeartext.Count)
        {
            isMethod = true;
            text[eventNumber - 1].SetActive(false);
            telop.gameObject.SetActive(false);
            enemy.isLeftMove = true; //敵キャラを左側へと移動させる
        }

        if (isMethod)
        {
            yield return null; //コルーチン実行中なのでイベントを実行させない
        }
        else
        {
            for (k = 0; k < appeartext.Count; k++)
            {
                if (k == eventNumber)
                {
                    //最初のテキストを出力する時だけ特殊な操作が入る
                    if (k == 0)
                    {
                        isMethod = true;
                        yield return new WaitForSeconds(1.5f); //ちょっと時間を空ける
                        telop.gameObject.SetActive(true); //最初にテキストを表示させる時にまずテロップ背景をアクティブにする
                        text[k].SetActive(true);
                        if (appeartext[k] != null)
                        {
                            yield return StartCoroutine(appeartext[k].AppearCenterText()); //メソッド終了(全てのテキストを出す）まで待つ
                        }
                        break;
                    }

                    text[k].SetActive(true);
                    if (appeartext[k] != null)
                    {
                        isMethod = true;
                        text[k - 1].SetActive(false);
                        text[k].SetActive(true);
                        yield return StartCoroutine(appeartext[k].AppearCenterText()); //メソッド終了(全てのテキストを出す）まで待つ
                        isMethod = false;
                    }
                    break;
                }
            }

            if (k == appeartext.Count)
            {
                Debug.Log("存在しないイベントナンバーです");
            }
        }

        yield return null; //何かしらの返り値を返す
    }

    //GameManagerでZキーが押されるのを感知したらこのメソッドが動く
    public void InputZkey()
    {
        if (!isMethod)
        {
            eventNumber++;
            EndingManager();
        }
        else
        {
            if(eventNumber == 0)
            {
                enemy.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("メソッド実行中です");
            }
        }
    }
}
