using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Imageオブジェクトにアタッチ*/
public class Image_Event1 : MonoBehaviour
{
    [SerializeField] FadeIn fadeIn;
    [SerializeField] FadeOut fadeOut;

    [SerializeField] int number; //フェードイン、アウトを繰り返す回数
    Image image; //imageコンポーネント

    private Vector3 imagePos; //この画像の相対座標
    private const float DefaultPictureHeight = 547;
    private float shakeWide; //振れ幅（片方)
    private int shakePattern; //0:上 1:真ん中 2:下 3:真ん中 0:上の状態にある
    private bool isShake; //画像を振っても良いか
    private int shakeNumber; //何回画像を振ったか

    private RectTransform ThisObjectTransform; //transformコンポーネント

    private bool isAppear;
    private bool isDisappear;
    private float alpha;


    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する
        ThisObjectTransform = this.GetComponent<RectTransform>();
        shakeWide = Mathf.Abs((ThisObjectTransform.sizeDelta.y - DefaultPictureHeight)/2); //振れ幅取得

        //初期化作業
        shakeNumber = 0;
        isShake = false;
        isAppear = false;
        isDisappear = false;
        alpha = 0.0f; //初期値は0
    }

    // Update is called once per frame
    void Update()
    {
        if(ThisObjectTransform != null)
        {
            imagePos = ThisObjectTransform.anchoredPosition; //相対座標を取得する
        }

        if (isAppear)
        {
            if (image != null)
            {
                image.color = new Color(1, 0, 0, alpha);
                alpha += 0.001f;
                if (alpha > 50/250f)
                {
                    isAppear = false;
                    isDisappear = true;
                    Debug.Log("Appear終了");
                }
            }
            else
            {
                Debug.Log("imageコンポーネントが取得できていません");
            }
        }

        if (isDisappear)
        {
            if (image != null)
            {
                image.color = new Color(1, 0, 0, alpha);
                alpha -= 0.001f;

                if(alpha <0.0f)
                {
                    isDisappear = false;
                    isAppear = true;
                    Debug.Log("Disppear終了");
                }
            }
            else
            {
                Debug.Log("imageコンポーネントが取得できていません");
            }
        }
    }

    private void FixedUpdate()
    {
        if (isShake)
        {
            switch (shakePattern)
            {
                case 0:
                    imagePos.y -= shakeWide;
                    shakePattern++;
                    break;

                case 1:
                    imagePos.y -= shakeWide;
                    shakePattern++;
                    break;

                case 2:
                    imagePos.y += shakeWide;
                    shakePattern++;
                    break;

                case 3:
                    imagePos.y += shakeWide;
                    shakePattern = 0;
                    break;
            }

            shakeNumber++;

            ThisObjectTransform.anchoredPosition = imagePos; //座標を更新する

            if(shakeNumber >= 300)
            {
                isShake = false;
            }
        }
    }

    public IEnumerator ThisObjectFadeIn()
    {
        yield return StartCoroutine(fadeIn.Fade()); //フェードインする
    }

    public IEnumerator ThisObjectFadeOut()
    {
        yield return StartCoroutine(fadeOut.Fade()); //フェードアウトする
    }

    //一定時間画像を揺らす
    public IEnumerator ImageShake()
    {
        Vector3 startpos = ThisObjectTransform.anchoredPosition; //初期の座標を格納する
        Debug.Log("振れ幅は"+ThisObjectTransform.sizeDelta.y + "-" + DefaultPictureHeight+"="+shakeWide);
        //最初,上にずらす
        imagePos.y += shakeWide;

        isShake = true;

        while (isShake)
        {
            yield return null; //画像を振り終えるまでメソッドを待機させる
        }
        //とりあえず1500回ゆらす
        ThisObjectTransform.anchoredPosition = startpos; //振動を終えたら戻す

        yield return null;
    }

    /*警報の画像の時赤色の画像の透明度を調整してチカチカを表現する*/
    public void ImageFadeInOut()
    {
        isAppear = true;
    }

    public void EndImageFadeInOut()
    {
        image.color = new Color(1, 0, 0, 0); //もう使わないので戻しておく
        isAppear = false;
        isDisappear = false;
    }
}
