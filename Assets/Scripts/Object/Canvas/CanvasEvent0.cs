using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvent0 : MonoBehaviour
{
    public bool isEnd; //このスクリプトの内容が全て終了したかどうか
    [SerializeField] Image_Opening image_Opening; //image_Openingクラスを取得する
    [SerializeField] Image_Opening image_ClosedEyes;
    [SerializeField] Text_Opening text_Opening;

    public int nowEvent = 1; //現在のイベント
    public bool nowMethod = false; //現在他クラスのコルーチンが実行中であるかどうか

    // Start is called before the first frame update
    void Start()
    {
        nowEvent = 1;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public IEnumerator Starting1()
    {
        Debug.Log("実行中");
        nowMethod = true;
        yield return StartCoroutine(text_Opening.Opening());
        nowMethod = false;
        Debug.Log("実行完了");
        nowEvent++;
    }

    public IEnumerator Starting2()
    {
        Debug.Log("２つ実行中");
        nowMethod = true;
        StartCoroutine(text_Opening.ThisObjectFadeIn());
        yield return StartCoroutine(image_Opening.ThisObjectFadeIn());
        nowMethod = false;
        Debug.Log("実行完了");
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        nowMethod = true;
        yield return StartCoroutine(image_ClosedEyes.ThisObjectFadeIn());
        nowMethod = false;
        isEnd = true;
    }
}
