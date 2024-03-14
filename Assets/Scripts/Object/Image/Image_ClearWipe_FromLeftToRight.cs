using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_ClearWipe_FromLeftToRight : MonoBehaviour
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
        widthLength = 987.5f;
        //現在のピボットの距離を取得
        offsetMinXY = rectTransformComponent.offsetMin;
        offsetMaxXY = rectTransformComponent.offsetMax;

        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            offsetMinXY.x += 3.0f; //徐々に右に寄せに行く

            //更新
            rectTransformComponent.offsetMin = offsetMinXY;
            rectTransformComponent.offsetMax = offsetMaxXY;

            //完全に透明化したらやめさせる
            if (offsetMinXY.x  > widthLength)
            {
                isActive = false;
                Debug.Log("終了");
            }
        }
    }

    //アクティブ時
    private void OnEnable()
    {
        isActive = true;
    }




}
