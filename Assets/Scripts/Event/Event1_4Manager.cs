using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_4Manager : MonoBehaviour
{
    [SerializeField] Text1_4_1 text1_4_1;

    [SerializeField] Image_Event1 image_Event1_4;

    public int nowEvent; //現在のイベント
    public bool nowMethod = false;
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        nowEvent = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        nowMethod = true;
        yield return StartCoroutine(text1_4_1.Starting()); //テキストを出力させる
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        nowMethod = true;
        StartCoroutine(image_Event1_4.ThisObjectFadeOut()); //背景をフェードアウトさせる
        Debug.Log("テキストをフェードアウトさせる");
        yield return StartCoroutine(text1_4_1.FadeOut()); //テキストをフェードアウトさせる
        Debug.Log("フェードアウト終了");


        yield return new WaitForSeconds(2.0f); //約2秒くらい止める
        Debug.Log("2秒止めました");

        nowMethod = false;
        isEnd = true;
    }
}
