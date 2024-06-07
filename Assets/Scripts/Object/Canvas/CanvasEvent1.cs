//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CanvasEvent1 : MonoBehaviour
//{
//    [SerializeField] Event1_1Manager event1_1Manager;
//    [SerializeField] Event1_2Manager event1_2Manager;
//    [SerializeField] Event1_3Manager event1_3Manager;

//    public bool isEnd = false;
//    public bool nowMethod = false; //現在メソッド(コルーチン)が実行中かどうか

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (event1_1Manager.isEnd)
//        {
//            event1_1Manager.isEnd = false;
//            NextEvent(2);
//        }

//        if (event1_2Manager.isEnd)
//        {
//            event1_2Manager.isEnd = false;
//            NextEvent(3);
//        }

//        if (event1_3Manager.isEnd)
//        {
//            event1_3Manager.isEnd = false;
//            NextEvent(4);
//        }
//    }

//    public IEnumerator Starting1()
//    {
//        Debug.Log("イベント1_1を開始します");
//        nowMethod = true;
//        yield return StartCoroutine(event1_1Manager.Starting1());
//        nowMethod = false;
//    }

//    public IEnumerator Starting2()
//    {
//        nowMethod = true;
//        Debug.Log("イベント1_2を開始します");
//        yield return StartCoroutine(event1_2Manager.Starting1());
//        nowMethod = false;
//    }

//    public IEnumerator Starting3()
//    {
//        nowMethod = true;
//        Debug.Log("イベント1_3を開始します");
//        yield return StartCoroutine(event1_3Manager.Starting1());
//        Debug.Log("end");
//    }

//    private void NextEvent(int nextNumber)
//    {
//        switch (nextNumber)
//        {
//            case 2:
//                StartCoroutine(Starting2());
//                break;

//            case 3:
//                StartCoroutine(Starting3());
//                break;

//            case 4:
//                isEnd = true;
//                Debug.Log("イベント1が終了しました");
//                break;

//            default:
//                Debug.Log("指定されたイベントが見つかりませんでした");
//                break;
//        }
//    }
//}
