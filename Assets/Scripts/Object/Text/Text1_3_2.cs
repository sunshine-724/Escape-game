using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1_3_2 : MonoBehaviour
{
    [SerializeField] Appeartext appeartext;
    [SerializeField] FadeIn fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting()
    {
        yield return StartCoroutine(appeartext.AppearCenterText()); //このメソッドを文字を出力できるまで止める
    }

    public IEnumerator ThisObjectFadeIn()
    {
        yield return StartCoroutine(fadeIn.Fade()); //フェードインを実行
    }
}
