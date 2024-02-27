using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*メインカメラオブジェクトにアタッチする*/

public class MainCameraManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Camera mainCameraComponent; //カメラコンポーネントを格納

    public Vector3 CameraPos; //カメラの座標
    private const float ObjectOffset = -10; //オブジェクトとの距離
    private const float stopCameraPositonX = -37; //プレイヤーとカメラの動きを同期させないようにする時のカメラのx座標
    private bool isMoveCamera; //カメラを動かしても良いか

    void Awake()
    {
        CameraPos = player.pos; //座標をプレイヤーと同じにする
        CameraPos.z += -10;  //カメラの座標に補正をかける
        mainCameraComponent.transform.position = CameraPos;
        isMoveCamera = true;
    }

    // Start is called before the first frame update
    private void Start()
    {   
        CameraPos = player.pos; //座標をプレイヤーと同じにする
        CameraPos.z += -10;  //カメラの座標に補正をかける
        mainCameraComponent.transform.position = CameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveCamera)
        {
            CameraPos = player.pos; //座標をプレイヤーと同じにする
            CameraPos.z += -10;  //カメラの座標に補正をかける
            mainCameraComponent.transform.position = CameraPos;
        }

        /*もし指定された場所までカメラが行ったら*/
        if(player.pos.x < stopCameraPositonX)
        {
            isMoveCamera = false; //カメラの動きを止める
        }
        else
        {
            isMoveCamera = true; //カメラの動きを再開する
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
        mainCameraComponent.projectionMatrix *= Matrix4x4.Scale(new Vector3(1, 1, 1)); //シェードの向きを元に戻す
    }
}
