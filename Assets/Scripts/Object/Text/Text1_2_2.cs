using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1_2_2 : MonoBehaviour
{
    [SerializeField] Appeartext appeartext;

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
        StartCoroutine(appeartext.AppearCenterText()); //真ん中から徐々に文字を出す
        yield return StartCoroutine(appeartext.AppearCenterText()); //このメソッドを文字を出力できるまで止める
    }
}
