using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBackGroundManager : MonoBehaviour
{
    [SerializeField] MainCameraManager mainCameraComponent;

    [SerializeField] Image_Background background0; //左側にある画像
    [SerializeField] Image_Background background1; //プレイヤーが最初に見る画像（中心)
    [SerializeField] Image_Background background2; //右側にある画像


    private Vector3 thisPosition; //このキャンバスの中心座標(最初に動的に取得する)
    private float imagewidth;  //中心画像の幅

    private const float ObjectOffset = 10; //カメラとの距離

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //メインカメラコンポーネントを取得するのがAwakeメソッドなので少しタイミングをずらす
        thisPosition = mainCameraComponent.transform.position; //メインカメラの位置を入手
        thisPosition.z += ObjectOffset; //カメラとの距離を調整

        if (thisPosition != null)
        {
            this.transform.position = thisPosition; //キャンバスの初期位置を調整
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
