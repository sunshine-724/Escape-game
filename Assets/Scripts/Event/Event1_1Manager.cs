using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_1Manager : MonoBehaviour
{
    [SerializeField] Text1_1_1 text1_1_1;
    [SerializeField] Image_Event1 image_Event1;

    public int nowEvent = 1; //現在のイベント
    public bool nowMethod = false; //現在他クラスのコルーチンが実行中であるかどうか
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
       nowEvent = 1; //現在のイベント
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_1_1.Starting()); //このメソッドで文字を出力できるまで止める
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting2()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_1_1.Starting2()); //このメソッドで次の文字列を出力できるまで止める
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        image_Event1.ThisObjectFadeIn();
        yield return StartCoroutine(text1_1_1.ThisObjectFadeIn());

        Debug.Log("イベント1_1のエンディングログ");
        isEnd = true;
    }
}
