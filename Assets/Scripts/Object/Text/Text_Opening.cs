using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Text_Openingにアタッチ*/
public class Text_Opening : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] Appeartext appeartext;
    [SerializeField] FadeIn fadeIn;
    [SerializeField] CanvasEvent0 canvasEvent0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Opening()
    {
        yield return StartCoroutine(appeartext.AppearCenterText()); //このメソッドを文字を出力できるまで止める
    }

    public IEnumerator ThisObjectFadeIn()
    {
        yield return StartCoroutine(fadeIn.Fade()); //フェードインを実行
    }
}
