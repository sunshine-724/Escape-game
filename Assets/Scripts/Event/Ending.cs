using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] Telop telop; //テロップ背景

    [SerializeField] Player player; //プレイヤー
    [SerializeField] Enemy enemy; //敵キャラ（研究員のクラス）

    private int eventNumber; //今どのイベントかを示す

    public bool isMethod; //今メソッドを実行中（コルーチンを実行中）であるかどうか

    [SerializeField] Image_Event1 image_Siren; //赤色の画像をチカチカさせる時のクラス
    [SerializeField] SoundBoxScript soundBox; //サイレンを鳴らすクラス

    private int textNumber; //今どのテキストを表示中なのかを示す
    [SerializeField] List<GameObject> text; //各テキストオブジェクト（アクティブか非アクティブかで表示するテキストを切り替える)
    [SerializeField] List<Appeartext> appeartext; //各テキストを出現するためのクラス

    /*エンドロール関連*/
    [SerializeField] float EndPositonx; //フェードアウトし終了する時のプレイヤーの座標
    private int endRollTextNumber; //今どのテキストを表示中なのかを示す
    [SerializeField] FadeOut Image_Fadeout; //フェードアウトする時の画像

    [SerializeField] GameObject endRollText_ParentObject; //親オブジェクト
    [SerializeField] List<GameObject> endRollText;
    [SerializeField] List<Appeartext> endRollAppearText;
    [SerializeField] GameObject soundBox_Ending;
    [SerializeField] RectTransform rect_NameText; //担当者の名前が書かれているテキスト集

    private void Awake()
    {
        eventNumber = 0; //最初は0
        textNumber = 0; //同じく0
        endRollTextNumber = 0; //同じく0

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーが右にいって出口に到達したら
        if((eventNumber == 14) && (player.pos.x >= EndPositonx)){
            eventNumber ++;
            EndingManager();
        }else if((eventNumber == 15) && (Image_Fadeout.isEnd)){
            eventNumber++;
            isMethod = false; //再びZキーの入力を受け付ける
            EndingManager();
        }else if(eventNumber == 19)
        {
            EndingManager();
        }
    }

    public void EndingManager()
    {
        Debug.Log("eventNumber" + eventNumber);
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
                isMethod = true; //Zキーの入力を受け付けないようにする
                break;

            case 15:
                //フェードアウト
                StartCoroutine(Image_Fadeout.Fade());
                break;

            case 16:
                //BGM開始
                Debug.Log("BGMを開始しました");
                soundBox_Ending.SetActive(true);
                //エンドロールテキスト0
                StartCoroutine(StartEndRollText());
                break;

            case 17:
                //エンドロールテキスト1
                StartCoroutine(StartEndRollText());
                break;

            case 18:
                //エンドロールテキスト2
                StartCoroutine(StartEndRollText());
                break;

            case 19:
                endRollText_ParentObject.SetActive(false);
                //エンドロール
                EndRoll_NameText();
                break;

            case 20:
                //タイトル画面に戻る
                Debug.Log("ゲーム終了");
                SceneManager.LoadScene("Title");
                break;

            default:
                Debug.Log("そのようなeventNumberは存在しません");
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

    private IEnumerator StartEndRollText()
    {
        int k; //カウンタ変数

        if (isMethod)
        {
            yield return null; //コルーチン実行中なのでイベントを実行させない
        }
        else
        {
            for (k = 0; k < endRollAppearText.Count; k++)
            {
                if (k == endRollTextNumber)
                {
                    //nullチェック
                    if (endRollAppearText[k] != null)
                    {
                        isMethod = true;
                        if (k != 0)
                        {
                            endRollText[k - 1].SetActive(false); //要素外アクセスを防ぐ
                        }
                        endRollText[k].SetActive(true);
                        yield return StartCoroutine(endRollAppearText[k].AppearCenterText()); //メソッド終了(全てのテキストを出す）まで待つ
                        endRollTextNumber++;
                        isMethod = false;
                    }
                    break;
                }
            }

            if (k == endRollAppearText.Count)
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

    //サイレンのチカチカ
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

    private void EndRoll_NameText()
    {
        //もしアクティブ状態ではなかったらアクティブにする
        if (!rect_NameText.gameObject.activeSelf)
        {
            rect_NameText.gameObject.SetActive(true);
        }

        if(rect_NameText != null)
        {
            Vector3 pos = rect_NameText.anchoredPosition;
            if(pos.y <= 535.0f)
            {
                isMethod = true;
                pos.y += 0.25f; //適宜調整
                rect_NameText.anchoredPosition = pos; //座標を更新する
            }
            else
            {
                isMethod = false; //入力を有効にする
            }
        }
        else
        {
            Debug.Log("エラー");
        }
    }
}
