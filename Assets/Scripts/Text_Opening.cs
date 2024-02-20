using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Text_Openingにアタッチ*/
public class Text_Opening : MonoBehaviour
{
    /*他クラスを取得する*/
    [SerializeField] GameManager gameManager;
    [SerializeField] Appeartext appeartext;
    // Start is called before the first frame update
    void Start()
    {
        Opening();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Opening()
    {
        StartCoroutine(appeartext.AppearText()); //徐々に文字を出す
        gameManager.UpdateEvent(1); //イベント1を許可する
    }
}
