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
    private int textNumber; //今どのテキストを表示中なのかを示す

    public bool isMethod; //今メソッドを実行中（コルーチンを実行中）であるかどうか

    [SerializeField] float EndPositonx; //フェードアウトし終了する時のプレイヤーの座標
    [SerializeField] FadeOut Image_Fadeout; //フェードアウトする時の画像

    [SerializeField] Image_Event1 image_Siren; //赤色の画像をチカチカさせる時のクラス
    [SerializeField] SoundBoxScript soundBox; //サイレンを鳴らすクラス

    private void Awake()
    {
        eventNumber = 0; //最初は0
        textNumber = 0; //同じく0

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーが右にいって出口に到達したら
        if((eventNumber >= appeartext.Count) && (player.pos.x >= EndPositonx)){
            eventNumber = -1;
            EndingManager();
        }
    }

    public void EndingManager()
    {
        Debug.Log("textnumber = " + textNumber + "appeartext.Count = " + appeartext.Count);
        switch (eventNumber)
        {
            case 0:
                //テキスト0
                telop.gameObject.SetActive(true);
                StartCoroutine(StartEndingText());
                break;

            case 1:
                //プレイヤーを左に向かせ、研究員を移動可能にする
                player.Left(); //プレイヤーを強制的に左へ向かせる
                enemy.gameObject.SetActive(true);
                break;

            case 2:
                //敵を画面に表示できるよう移動させる
                enemy.gameObject.SetActive(true);
                break;

            case 3:
                //テキスト1
                StartCoroutine(StartEndingText());
                break;

            case 4:
                //テキスト2
                StartCoroutine(StartEndingText());
                break;

            case 5:
                //テキスト3
                StartCoroutine(StartEndingText());
                break;

            case 6:
                //サイレンを鳴らす
                StartCoroutine(ContinueSiren());
                break;

            case 7:
                //研究員を左に向ける
                enemy.Rotation("left");
                break;

            case 8:
                //テキスト4
                StartCoroutine(StartEndingText());
                break;

            case 9:
                //研究員を右に向ける
                enemy.Rotation("right");
                break;

            case 10:
                //テキスト5
                StartCoroutine(StartEndingText());
                break;

            case 11:
                //テキスト6
                StartCoroutine(StartEndingText());
                break;

            case 12:
                //テキスト7
                StartCoroutine(StartEndingText());
                break;

            case 13:
                //テキストとその背景を消し、研究員を再び左に向け、画面外に移動させる
                isMethod = true;
                text[textNumber - 2].SetActive(false);
                text[textNumber - 1].SetActive(false);
                telop.gameObject.SetActive(false);
                enemy.Rotation("left");
                enemy.isLeftMove = true; //敵キャラを左側へと移動させる
                break;

            case 14:
                //プレイヤーを行動可能にする
                player.IsMove(true);
                enemy.gameObject.SetActive(false);
                break;
        }
    }

    private IEnumerator StartEndingText()
    {
        int k; //カウンタ変数

        if (isMethod)
        {
            yield return null; //コルーチン実行中なのでイベントを実行させない
        }
        else
        {
            for (k = 0; k < appeartext.Count; k++)
            {
                if (k == textNumber)
                {
                    if (appeartext[k] != null)
                    {
                        isMethod = true;
                        if((k != 0) && (k != 7))
                        {
                            text[k - 1].SetActive(false); //要素外アクセスを防ぐ
                        }
                        text[k].SetActive(true);
                        yield return StartCoroutine(appeartext[k].AppearCenterText()); //メソッド終了(全てのテキストを出す）まで待つ
                        textNumber++;
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
            Debug.Log("メソッド実行中です");
        }
    }

    private IEnumerator ContinueSiren()
    {
        //チカチカ実行
        isMethod = true;
        soundBox.gameObject.SetActive(true); //音を鳴らす
        image_Siren.ImageFadeInOut();
        yield return new WaitForSeconds(5.0f); //しばらくの間サイレンを鳴らす
        image_Siren.EndImageFadeInOut();
        soundBox.gameObject.SetActive(false); //音を止める
        isMethod = false;
    }
}
