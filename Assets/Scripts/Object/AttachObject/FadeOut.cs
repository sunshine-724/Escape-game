using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*フェードアウトするようのimageオブジェクトを作りそこにアタッチする*/
public class FadeOut : MonoBehaviour
{
    /*変数宣言*/
    float alpha; //出力する透明度
    float alphaMax = 1.0f; //rgbの最高値
    [SerializeField] float fadeSpeed; //インスペクタでスピードを指定
    [SerializeField] float specifyAlphaMax; //必要ならalphaMaxの値を指定する（指定しなかったら最大値が適応される)

    bool isActive; //フェードアウトを実行しても良いか

    public bool isEnd { get; private set; } //フェードアウトが終了したらフラグを立てる


    Image image; //imageコンポーネント
    Text text; //テキストコンポーネント

    private void Awake()
    {
        image = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する
        text =this.GetComponent<Text>(); //このオブジェクトのテキストコンポーネントを取得する

        alpha = 0.5f; //初期値
        isEnd = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //もし値が指定されていたら値を書き換える
        if (specifyAlphaMax != 0)
        {
            alphaMax = specifyAlphaMax;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            //もし指定したコンポーネントがnullではなかったらフェードアウトさせる
            if (image != null)
            {
                image.color = new Color(0, 0, 0, alpha);
            }

            if (text != null)
            {
                text.color = new Color(0, 0, 0, alpha);
            }

            alpha += fadeSpeed;

            if (alpha >= 1.1f)
            {
                Debug.Log("フェードアウトを終了しました");
                isActive = false;
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

        isEnd = true;
        yield return fadeSpeed;
    }
}
