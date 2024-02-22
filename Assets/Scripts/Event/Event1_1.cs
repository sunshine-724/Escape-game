using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_1 : MonoBehaviour
{
    /*親オブジェクト*/
    [SerializeField] CanvasEvent1 canvasEvent1;

    /*子オブジェクト*/
    [SerializeField] Event1_1Text event1Text1;
    [SerializeField] Event1_1Text event1Text2;
    [SerializeField] Event1_1Text event1Text3;
    [SerializeField] Event1_1Text event1Text4;
    [SerializeField] Event1_1Text event1Text5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Event1()
    {
        Debug.Log("テキスト１が開始されました");
        StartCoroutine(event1Text1.TextObjectActive());
        yield return StartCoroutine(event1Text1.TextObjectActive());

        StartCoroutine(Event2());
    }

    private IEnumerator Event2()
    {
        Debug.Log("テキスト2が開始されました");
        StartCoroutine(event1Text2.TextObjectActive());
        yield return StartCoroutine(event1Text2.TextObjectActive());

        StartCoroutine(Event3());
    }

    private IEnumerator Event3()
    {
        Debug.Log("テキスト3が開始されました");
        StartCoroutine(event1Text3.TextObjectActive());
        yield return StartCoroutine(event1Text3.TextObjectActive());
        StartCoroutine(Event4());
    }

    private IEnumerator Event4()
    {
        Debug.Log("テキスト4が開始されました");
        StartCoroutine(event1Text4.TextObjectActive());
        yield return StartCoroutine(event1Text4.TextObjectActive());
        StartCoroutine(Event5());
    }

    private IEnumerator Event5()
    {
        Debug.Log("テキスト5が開始されました");
        StartCoroutine(event1Text5.TextObjectActive());
        yield return StartCoroutine(event1Text5.TextObjectActive());

        canvasEvent1.EndEvent(1);
    }
}
