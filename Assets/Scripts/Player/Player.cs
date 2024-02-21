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
    private int touchTeleportObject; //何番目のテレポートオブジェクトと接しているか(していない場合-1を格納)

    private bool isZKey; //Zキーを押したらイベントを発生さしても良いか

    /*オブジェクトを取得する*/
    /*子オブジェクト*/
    [SerializeField] GameObject runObject; //キャラが走る
    [SerializeField] GameObject idleObject; //キャラが待機する
    [SerializeField] GameObject jumpObject; //キャラがジャンプする

    /*子クラスを取得する*/
    [SerializeField] CharacterMove characterMove;
    [SerializeField] MainCameraManager mainCamera;

    /*他クラスを取得する*/
    [SerializeField] Planes planes;
    [SerializeField] TeleportObjects teleObjects;

    /*クラスは同じだがインスタンスが異なる(テレポート元)*/
    [SerializeField] TeleportObject teleObject0;
    [SerializeField] TeleportObject teleObject1;
    [SerializeField] TeleportObject teleObject2;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(0.0f, 0.0f, 0.0f); //変数を初期化

        runObject.SetActive(false); //走るのを非アクティブ化
        jumpObject.SetActive(false); //ジャンプを非アクティブ化
        idleObject.SetActive(true); //待機をアクティブ化
        isJumping = false; //初期状態はfalse

        isZKey = false; //初期状態はfalse
        touchTeleportObject = -1; //最初はどことも接していないので-1
    }

    // Update is called once per frame
    void Update()
    {
        /*現在座標を取得する*/
        pos = this.transform.position;

        /*テレポーター関係*/
        if(isZKey == true)
        {
            //もし許可が下りててZキーが押されたら
            if (Input.GetKeyDown(KeyCode.Z))
            {
               switch (touchTeleportObject)
                {
                    case 0:
                        teleObject0.Teleport(this); //テレポートする
                        break;

                    case 1:
                        teleObject1.Teleport(this); //テレポートする
                        break;

                    case 2:
                        teleObject2.Teleport(this); //テレポートする
                        break;

                    default:
                        Debug.Log("そのテレポーターは登録されていません");
                        break;
                }

                isZKey = false; //一度無効化する
            }
        }

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
            //Debug.Log("planes is not null");
            for (int k = 0; k < planes.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planes.plane[k])
                {
                    isJumping = true;
                    //Debug.Log(k + "番目の床に当たっています");
                    break;
                }
            }
            //Debug.Log("正常にループを抜けました");
        }
        else
        {
            //たまにnullになるのでnullチェックを入れて回避
            //Debug.Log("planes is null");
        }
    }

    //テレポーターとの接地判定
    public void OnTriggerStay2D(Collider2D collision)
    {
        //nullチェック(nullの場合アクセスするとNullReferenceを返されるので判定しない)
        if (teleObjects != null)
        {
            //テレポーターとの衝突判定
            for (int k = 0; k < teleObjects.childObjectNumbers; k++)
            {
                /*テレポーターと接しているか*/
                if ((collision.gameObject == teleObjects.childObjects[k].gameobject))
                {
                    Debug.Log(k + "番目のテレポーターと接しています");
                    //そのテレポーターが使用可能なら指定された所へテレポートする
                    if (teleObjects.childObjects[k].isTeleport == true)
                    {
                        Debug.Log("接しているテレポーターは使用可能です");
                        isZKey = true; //Zキーを押したら反応するようにする
                        touchTeleportObject = k; //接しているテレポーターに設定する
                    }
                    else
                    {
                        Debug.Log("接しているテレポーターは使用できません");
                    }
                }
                else
                {
                  
                }

                //どのテレポーターとも接していない場合
                if (k ==teleObjects.childObjectNumbers)
                {
                    Debug.Log("どのテレポーターとも接していません");
                    isZKey = false; //Zキーを押しても反応しないようにする
                    touchTeleportObject = -1; //どことも接していないので
                }
            }
        }
        else
        {
            //Debug.Log("teleObjects is null");
        }
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
