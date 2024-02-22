using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvent0 : MonoBehaviour
{

    [SerializeField] Image_Opening image_Opening; //image_Openingクラスを取得する
    [SerializeField] Text_Opening text_Opening;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEvent0()); //デバッグ
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public IEnumerator StartEvent0()
    {
        Debug.Log("実行中");
        yield return StartCoroutine(text_Opening.Opening());
        Debug.Log("実行完了");
        Debug.Log("２つ実行中");
        StartCoroutine(text_Opening.ThisObjectFadeIn());
        yield return StartCoroutine(image_Opening.ThisObjectFadeIn());
        Debug.Log("実行完了");
    }
}
