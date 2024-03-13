using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_2Manager : MonoBehaviour
{
    /*子クラスを取得する*/
    [SerializeField] Image_Event1 image_Event1_2;

    [SerializeField] Telop telop1_2_1;
    [SerializeField] Telop telop1_2_2;

    [SerializeField] TextObject text1_2_1;
    [SerializeField] TextObject text1_2_2;

    [SerializeField] TelopBackGround telopBackGround1;
    [SerializeField] TelopBackGround telopBackGround2;

    public int nowEvent = 1; //現在のイベント
    public bool nowMethod = false; //現在他クラスのコルーチンが実行中であるかどうか
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
        telop1_2_2.gameObject.SetActive(false); //EnemyBのセリフを非アクティブにする
        yield return StartCoroutine(text1_2_1.Starting()); //EnemyAのセリフを待つ
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting2()
    {
        nowMethod = true;
        telop1_2_1.gameObject.SetActive(false); //EnemyBのセリフが挟むので一度EnemyAのセリフを一時的に非アクティブにする
        telop1_2_2.gameObject.SetActive(true); //EnemyBのセリフのアクティブにする
        yield return StartCoroutine(text1_2_2.Starting()); //EnemyBのセリフを待つ
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Starting3()
    {
        nowMethod = true;
        telop1_2_2.gameObject.SetActive(false); //EnemyBのセリフを非アクティブにする
        telop1_2_1.gameObject.SetActive(true); //EnemyAのセリフが来るので再びアクティブにする
        yield return StartCoroutine(text1_2_1.Starting2()); //EnemyAのセリフを待つ
        nowMethod = false;
        nowEvent++;
    }

    public IEnumerator Ending()
    {
        nowMethod = true;
        StartCoroutine(image_Event1_2.ThisObjectFadeIn());
        StartCoroutine(telopBackGround1.ThisObjectFadeIn());
        StartCoroutine(telopBackGround2.ThisObjectFadeIn());
        yield return StartCoroutine(text1_2_1.ThisObjectFadeIn());
        nowMethod = false;

        Debug.Log("イベント1_2のエンディングログ");
        isEnd = true;
    }
}
