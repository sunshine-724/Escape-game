using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1Text1 : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] Appeartext appeartext;

    private bool outputText = true; //テキストを出力しても良いか(最初はtrue)

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

    public void TextObjectActive()
    {
        if (outputText)
        {
            appeartext.AppearCenterText(); //テキストを出力させる
            outputText = false; //2度とこのメソッドが実行できないようにする
        }
        else
        {
            Debug.Log("このメソッドは使用できません");
        }
        
    }
}
