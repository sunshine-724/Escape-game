using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

///*image_openingにアタッチする*/
//public class Image_Opening : MonoBehaviour
//{
//    /*変数宣言*/
//    float alpha; //出力する透明度
//    const float alphaMax = 1.0f; //透明度の最高値

//    /*親オブジェクト(このオブジェクト)関連*/
//    Image thisObjectImage; //imageコンポーネント

//    /*子オブジェクト関連*/
//    Transform childObjectTransform; //子オブジェクトのtransform
//    Text childObjectText; //テキストコンポーネント

//    private void Awake()
//    {
//        thisObjectImage = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する

//        /*子オブジェクト関連*/
//        childObjectTransform = this.transform.GetChild(0); //子オブジェクトを取得
//        if (childObjectTransform != null)
//        {
//            childObjectText = childObjectTransform.gameObject.GetComponent<Text>(); //子オブジェクトのテキストコンポーネントを取得する
//        }
//        else
//        {
//            Debug.Log("子オブジェクトを取得できませんでした");
//        }

//        alpha = alphaMax; //初期値

//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }



//    public IEnumerator Fade()
//    {
//        for (alpha = alphaMax; alpha >= 0; alpha -= 0.01f)
//        {
//            thisObjectImage.color = new Color(0, 0, 0, alpha);
//            childObjectText.color = new Color(1, 1, 1, alpha);
//            yield return null;
//        }
//    }
//}
