using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*フェードインしたいオブジェクトにアタッチする*/
public class FadeIn : MonoBehaviour
{
    /*変数宣言*/
    float alpha; //出力する透明度
    const float alphaMax = 1.0f; //透明度の最高値
    [SerializeField] float fadeSpeed; //インスペクタでスピードを指定

    Image image; //imageコンポーネント
    Text text; //テキストコンポーネント

    private void Awake()
    {
        image = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する
        text =this.GetComponent<Text>(); //このオブジェクトのテキストコンポーネントを取得する

        alpha = alphaMax; //初期値
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public IEnumerator Fade()
    {
        for (alpha = alphaMax; alpha >= 0; alpha -= 0.01f)
        {
            //もし指定したコンポーネントがnullではなかったらフェードインさせる
            if(image != null)
            {
                image.color = new Color(0, 0, 0, alpha);
            }

            if(text != null)
            {
                text.color = new Color(1, 1, 1, alpha);
            }
            
            yield return fadeSpeed;
        }
    }
}
