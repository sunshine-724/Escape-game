using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_3Manager : MonoBehaviour
{
    [SerializeField] Text1_3_1 text1_3_1;
    [SerializeField] Text1_3_2 text1_3_2;

    [SerializeField] Image_Event1 image_Event1_3_1;

    public int nowEvent = 0; //現在のイベント
    public bool nowMethod = false;
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        nowEvent = 1; //初期化
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_3_1.Starting()); //EnemyA
        Debug.Log("コルーチン完了");
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting2()
    {
        nowMethod = true;
        text1_3_1.gameObject.SetActive(false); //EnemyBのセリフが挟むので一度EnemyAのセリフを一時的に非アクティブにする
        yield return StartCoroutine(text1_3_2.Starting()); //EnemyBのセリフを待つ
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting3()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_3_2.ThisObjectFadeIn()); //ここはテキストをフェードインさせる
        nowMethod = false;

        nowMethod = true;
        Debug.Log("画像を揺らします");
        yield return StartCoroutine(image_Event1_3_1.ImageShake()); //画像を揺らす
        nowMethod = false;

        nowMethod = true;
        Debug.Log("警報の画像を差し込みます");

        nowEvent++;
    }

    public IEnumerator Ending()
    {
        nowMethod = true;
        yield return StartCoroutine(image_Event1_3_1.ThisObjectFadeIn()); //
        nowMethod = false;

        yield return null;

        Debug.Log("イベント1_3のエンディングログ");
        isEnd = true;
    }


}
