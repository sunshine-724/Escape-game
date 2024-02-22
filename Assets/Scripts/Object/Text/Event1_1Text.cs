using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1_1Text : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] Appeartext appeartext;

    // Start is called before the first frame update

    private void Awake()
    {
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public IEnumerator TextObjectActive()
    {
        StartCoroutine(appeartext.AppearCenterText()); //テキストを出力させる
        yield return StartCoroutine(appeartext.AppearCenterText()); //上のメソッドが終わるまで待つ
    }
}
