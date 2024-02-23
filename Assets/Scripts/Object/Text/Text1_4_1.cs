using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1_4_1 : MonoBehaviour
{
    [SerializeField] Appeartext appeartext;
    [SerializeField] FadeIn fadeIn;
    [SerializeField] FadeOut fadeOut;

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

    public IEnumerator FadeOut()
    {
        yield return StartCoroutine(fadeOut.Fade()); //フェードアウトさせる
    }
}
