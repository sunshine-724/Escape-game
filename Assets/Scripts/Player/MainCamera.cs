using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*メインカメラオブジェクトにアタッチする*/

public class MainCamera : Player
{
    Camera mainCamera; //カメラコンポーネントを格納

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>(); //カメラコンポーネントを取得する
    }

    // Update is called once per frame
    void Update()
    {

    }

    //カメラを反転させる
    public void CameraReverseRotation()
    {
        mainCamera.ResetProjectionMatrix(); //シェードを取得
        mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1)); //シェードの向きを変える
    }

    //カメラを元に戻す
    public void CameraBaseRotation()
    {
        mainCamera.ResetProjectionMatrix(); //シェードを取得
        mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(1, 1, 1)); //シェードの向きを元に戻す
    }
}
