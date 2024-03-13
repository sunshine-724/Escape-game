using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*フェードインしたいオブジェクトにアタッチする*/
public class FadeIn : MonoBehaviour
{
    /*変数宣言*/
    float alpha; //出力する透明度
    float alphaMax = 1.0f; //透明度の最高値
    bool isActive = false; //フェードインを実行しても良いか
    [SerializeField] float fadeSpeed; //インスペクタでスピードを指定
    [SerializeField] float specifyAlphaMax; //必要ならalphaMaxの値を指定する（指定しなかったら最大値が適応される)

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
        //もし値が指定されていたら値を書き換える
        if (specifyAlphaMax != 0)
        {
            alphaMax = specifyAlphaMax;
        }

        alpha = alphaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            //もし指定したコンポーネントがnullではなかったらフェードインさせる
            if (image != null)
            {
                image.color = new Color(0, 0, 0, alpha);
            }

            if (text != null)
            {
                text.color = new Color(1, 1, 1, alpha);
            }

            alpha -= fadeSpeed;

            if(alpha <= -0.1f)
            {
                Debug.Log("フェードインを終了しました");
                isActive = false; //フェードインをやめさせる
            }
        }
    }



    public IEnumerator Fade()
    {

        isActive = true;

        while (isActive)
        {
            yield return null;
        }

        //isActiveがfalseになったら
        yield return fadeSpeed;

    }
}
