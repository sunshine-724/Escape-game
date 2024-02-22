using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_1Manager : MonoBehaviour
{
    [SerializeField] Text1_1_1 text1_1_1;
    [SerializeField] Image_Event1 image_Event1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Starting1()); //debug
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        yield return StartCoroutine(text1_1_1.Starting()); //このメソッドで文字を出力できるまで止める

        Debug.Log("次の文字列が再生されます");
        StartCoroutine(Starting2()); //debug
    }

    public IEnumerator Starting2()
    {
        yield return StartCoroutine(text1_1_1.Starting2()); //このメソッドで文字を出力できるまで止める

        StartCoroutine(Ending()); //debug
    }

    public IEnumerator Ending()
    {
        yield return StartCoroutine(text1_1_1.ThisObjectFadeIn());
        image_Event1.ThisObjectFadeIn();
    }
}
