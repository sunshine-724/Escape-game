using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

/*プレイヤーオブジェクトにアタッチする*/
public class Player : MonoBehaviour
{
    /*変数宣言*/
    private bool isJumping; //ジャンプしても良いか
    private bool isTeleport; //(仮)
    private const float fallPositon = -10; //プレイヤーが落下したとみなす座標(調整可能)
    [System.NonSerialized] public Vector3 pos; //Playerの現在座標(読み取り専用）

    /*オブジェクトを取得する*/
    /*子オブジェクト*/
    [SerializeField] GameObject runObject; //キャラが走る
    [SerializeField] GameObject idleObject; //キャラが待機する
    [SerializeField] GameObject jumpObject; //キャラがジャンプする

    /*子クラスを取得する*/
    [SerializeField] CharacterMove characterMove;
    [SerializeField] MainCamera mainCamera;

    /*他クラスを取得する*/
    [SerializeField] Planes planes;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0.0f, 0.0f, 0.0f); //変数を初期化

        runObject.SetActive(false); //走るのを非アクティブ化
        jumpObject.SetActive(false); //ジャンプを非アクティブ化
        idleObject.SetActive(true); //待機をアクティブ化
        isJumping = false; //初期状態はfalse
    }

    // Update is called once per frame
    void Update()
    {
        /*現在座標を取得する*/
        pos = this.transform.position;

        /*キーを取得する*/
        //水平キーを取得する
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            idleObject.SetActive(false);
            jumpObject.SetActive(false);
            runObject.SetActive(true);
            mainCamera.CameraBaseRotation(); //カメラを元の向きに戻す
            characterMove.Right(this); //右側に移動する      
        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            idleObject.SetActive(false);
            jumpObject.SetActive(false);
            runObject.SetActive(true);
            mainCamera.CameraReverseRotation(); //親オブジェクトを反転させたのでカメラを反転させる
            characterMove.Left(this); //左側に移動する
        }
        else
        {
            //待機モーション
            runObject.SetActive(false);
            jumpObject.SetActive(false);
            idleObject.SetActive(true);
        }

        //垂直キーを取得する
        if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) && (isJumping))
        {
            idleObject.SetActive(false);
            runObject.SetActive(false);
            jumpObject.SetActive(true);
            characterMove.Jump(this); //ジャンプする

            isJumping = false; //連続でジャンプできないようにする
        }

        /*毎フレーム落下判定する*/
        FallPlayer();
    }

    /*衝突判定*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        //床の衝突判定
        if (planes != null)
        {
            Debug.Log("planes is not null");
            for (int k = 0; k < planes.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planes.plane[k])
                {
                    isJumping = true;
                    Debug.Log(k + "番目の床に当たっています");
                    break;
                }
            }
        }
        else
        {
            //たまにnullになるのでnullチェックを入れて回避
            Debug.Log("planes is null");
        }
        Debug.Log("正常にループを抜けました");
    }

/*落下判定*/
private void FallPlayer()
    {
        //もし落下したらゲームオーバー画面を出す
        if(pos.y <= fallPositon)
        {
            Debug.Log("落下したのでゲームオーバー画面を表示します");
        }
    }
}
