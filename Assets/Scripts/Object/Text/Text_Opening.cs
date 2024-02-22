using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Text_Openingにアタッチ*/
public class Text_Opening : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] GameManager gameManager;
    [SerializeField] Appeartext appeartext;
    [SerializeField] CanvasEvent0 canvasEvent0;

    public bool end = false; //このオブジェクトのメソッドの終了の合図
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
        StartCoroutine(appeartext.AppearCenterText()); //真ん中から徐々に文字を出す
        yield return StartCoroutine(appeartext.AppearCenterText()); //このメソッドを文字を出力できるまで止める

        /*再開したら*/
        end = true;
        Debug.Log("trueにしました");
        yield break; //メソッド終了
    }
}
