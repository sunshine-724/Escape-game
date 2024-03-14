using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_BlackWipe_FromLeftToRight : MonoBehaviour
{
    RectTransform rectTransformComponent;
    float widthLength; //画像の横幅
    Vector2 offsetMinXY; //ピボットのleftとdown
    Vector2 offsetMaxXY; //ピボットのrightとup

    public bool isActive { get;private set;} //このゲームオブジェクトのシーン切り替えを開始しても良いか
    private void Awake()
    {
        rectTransformComponent = GetComponent<RectTransform>(); //コンポーネントを取得する

        isActive = false;
        //画像の横幅を取得する
        widthLength = rectTransformComponent.sizeDelta.x;
        //現在のピボットの距離を取得
        offsetMinXY = rectTransformComponent.offsetMin;
        offsetMaxXY = rectTransformComponent.offsetMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            offsetMaxXY.x += 2.0f; //徐々に右に寄せに行く

            //更新
            rectTransformComponent.offsetMin = offsetMinXY;
            rectTransformComponent.offsetMax = offsetMaxXY;

            //完全にブラックアウト化したらやめさせる
            if (offsetMaxXY.x > 0)
            {
                Debug.Log("条件を満たしました");
                isActive = false;
            }

        }
    }

    //アクティブ時
    private void OnEnable()
    {
        isActive = true;
    }




}
