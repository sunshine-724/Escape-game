using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_1Manager : MonoBehaviour
{
    [SerializeField] Text1_1_1 text1_1_1;
    [SerializeField] Image_Event1 Image1_1_1OpenEyes;
    [SerializeField] Image_Event1 image1_1_2Prison;

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
        //保留
        //nowMethod = true;
        //yield return StartCoroutine(Image1_1_1OpenEyes.ThisObjectFadeIn()); //画像を非表示
        //Debug.Log("画像を表示させました");
        //nowMethod = false;
        yield return null; //仮コード
        nowEvent++;
    }

    public IEnumerator Starting2()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_1_1.Starting()); //「あれ・・？ここどこ？」
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting3()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_1_1.Starting2()); //「私は確か・・・ご飯を探してて、それで・・・。」
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        StartCoroutine(image1_1_2Prison.ThisObjectFadeIn());

        yield return StartCoroutine(Image1_1_1OpenEyes.ThisObjectFadeIn()); //画像を非表示（仮コード)
        yield return StartCoroutine(text1_1_1.ThisObjectFadeIn());

        Debug.Log("イベント1_1のエンディングログ");
        isEnd = true;
    }
}
