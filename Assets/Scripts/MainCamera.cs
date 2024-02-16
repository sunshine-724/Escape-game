using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*メインカメラオブジェクトにアタッチする*/

public class MainCamera : Player
{

    Transform mainCameraTransform = null;

    // Start is called before the first frame update
    void Start()
    {
       mainCameraTransform = gameObject.GetComponent<Transform>(); //メインカメラオブジェクトの'transform'コンポーネントを取得する
    }

    // Update is called once per frame
    void Update()
    {

    }

    //カメラを反転させる
    public void CameraReverseRotation()
    {
        if (mainCameraTransform != null)
        {
            this.mainCameraTransform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            this.mainCameraTransform.Rotate(0.0f, 180.0f, 0.0f); //デバッグ
            Debug.Log("カメラを反転させています");
        }
        else
        {
            Debug.Log("カメラオブジェクトが入手できていません");
        }
    }

    //カメラを元に戻す
    public void CameraBaseRotation()
    {
        if (mainCameraTransform != null)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
