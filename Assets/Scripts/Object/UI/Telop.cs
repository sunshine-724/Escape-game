using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telop : MonoBehaviour
{
    [SerializeField] FadeIn fadeIn;

    [SerializeField] TextObject textObject;
    [SerializeField] TelopBackGround telopBackGround;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //子オブジェクトのテキスト本体と背景をフェードインさせる
    public IEnumerator ThisObjectFadeIn()
    {
        StartCoroutine(telopBackGround.ThisObjectFadeIn()); //背景
        yield return StartCoroutine(textObject.ThisObjectFadeIn()); //本体
    }
}
