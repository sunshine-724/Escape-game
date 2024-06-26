using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_4Manager : MonoBehaviour
{
    [SerializeField] TelopBackGround telopBackGround;
    [SerializeField] TextObject text1_4_1;
    [SerializeField] TextObject text1_4_2;
    [SerializeField] TextObject text1_4_3;
    [SerializeField] TextObject text1_4_4;


    [SerializeField] Image_Event1 image_Event1_4_1;

    [SerializeField] Image_Event1 image_Event1_4_2;

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

    public IEnumerator Starting2()
    {
        nowMethod = true;
        text1_4_1.gameObject.SetActive(false);
        yield return StartCoroutine(text1_4_2.Starting()); //テキストを出力させる
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting3()
    {
        nowMethod = true;
        text1_4_2.gameObject.SetActive(false);
        yield return StartCoroutine(text1_4_3.Starting()); //テキストを出力させる
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting4()
    {
        nowMethod = true;
        text1_4_3.gameObject.SetActive(false);
        yield return StartCoroutine(text1_4_4.Starting()); //テキストを出力させる
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        nowMethod = true;
        yield return StartCoroutine(image_Event1_4_2.ThisObjectFadeOut());
        Debug.Log("フェードアウト終了");

        nowMethod = false;
        isEnd = true;
    }
}
