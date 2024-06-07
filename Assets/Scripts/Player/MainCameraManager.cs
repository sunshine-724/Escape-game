using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*メインカメラオブジェクトにアタッチする*/

public class MainCameraManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameManager gameManager; //シーンによってカメラに補正をかける
    [SerializeField] Camera mainCameraComponent; //カメラコンポーネントを格納

    public Vector3 CameraPos; //カメラの座標
    private bool isMoveCamera; //カメラを動かしても良いか

    void Awake()
    {
        //EventNumberが０以上４以下または１０の場合追跡せずカメラを固定する
        if(((0<= gameManager.EventNumber) && (gameManager.EventNumber <= 4))||(gameManager.EventNumber == 10)){
            isMoveCamera = false;
        }
        else
        {
            isMoveCamera = true;
        }

        if (isMoveCamera)
        {
            CameraPos = player.pos; //座標をプレイヤーと同じにする
            CameraPos.z += -10;  //カメラの座標に補正をかける
            mainCameraComponent.transform.position = CameraPos;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {   

        if(gameManager.EventNumber == 3)
        {
            CameraPos.y = 11.25f; //カメラのy座標を固定する
        }
    }

    // Update is called once per frame
    void Update()
    {
        //イベント毎にカメラの挙動を変える
        switch (gameManager.EventNumber)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                if (isMoveCamera)
                {
                    CameraPos.x = player.pos.x; //x座標をプレイヤーと同じにする
                    CameraPos.y = player.pos.y; //y座標をプレイヤーと同じにする
                }
                break;

            case 3:
                if (isMoveCamera)
                {
                    CameraPos.x = player.pos.x; //x座標をプレイヤーと同じにする
                    CameraPos.y = player.pos.y; //y座標をプレイヤーと同じにする
                }
                break;

            default:
                if(gameManager.EventNumber >= 5)
                {
                    CameraPos.x = player.pos.x; //x座標をプレイヤーのx座標と同じにする
                }
                break;
        }

        if (isMoveCamera)
        {
            mainCameraComponent.transform.position = CameraPos; //座標を更新する
        }
    }

    //カメラを反転させる
    public void CameraReverseRotation()
    {
        transform.RotateAround(this.transform.position, new Vector3(0, 0, 0), 0f);
    }

    //カメラを元に戻す
    public void CameraBaseRotation()
    {
        transform.RotateAround(this.transform.position, new Vector3(1, 0, 0), 0f);
        mainCameraComponent.ResetProjectionMatrix(); //シェードを取得
    }
}
