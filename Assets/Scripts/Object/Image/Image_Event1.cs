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
    private RectTransform ThisObjectTransform; //transformコンポーネント

    private bool isAppear;
    private bool isDisappear;
    private float alpha;
    float fadeSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する
        ThisObjectTransform = this.GetComponent<RectTransform>();
        shakeWide = Mathf.Abs((ThisObjectTransform.sizeDelta.y - DefaultPictureHeight)/2); //振れ幅取得

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
        Debug.Log("振れ幅は"+ThisObjectTransform.sizeDelta.y + "-" + DefaultPictureHeight+"="+shakeWide);
        //最初,上にずらす
        imagePos.y += shakeWide;

        //とりあえず50回ゆらす
        for(int k = 0; k <1500; k++)
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

            ThisObjectTransform.anchoredPosition = imagePos; //座標を更新する 

            yield return new WaitForSeconds(1/10000000000000000f); //秒数は適宜調整
        }
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
