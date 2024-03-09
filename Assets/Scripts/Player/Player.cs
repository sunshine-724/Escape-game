using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

/*プレイヤーオブジェクトにアタッチする*/
public class Player : MonoBehaviour
{
    /*変数宣言*/
    //キャラのパラメータ関連
    [SerializeField] float speed; //キャラの移動スピード
    [SerializeField] Vector2 jumpForce = new Vector2(0.0f, 15.0f); //ジャンプの強さ(インスペクタで調整可能)
    [System.NonSerialized] public Vector3 pos; //Playerの現在座標(読み取り専用）

    //フラグ関連
    private bool isZKey; //Zキーを押したらイベントを発生しても良いか
    public bool isMove; //プレイヤーが動いても良いか
    private bool isJumping; //ジャンプしても良いか
    public bool isRightMove;
    public bool isLeftMove; //イベント1において左方向へ移動はできないようにする(GameManagerのみ書き換え可能)

    //SE関連
    private bool isRunStepSound; //ステップサウンドが連続して再生されないようにする

    //その他
    private const float fallPositon = -10; //プレイヤーが落下したとみなす座標(調整可能)
    private int touchTeleportObject; //何番目のテレポートオブジェクトと接しているか(していない場合-1を格納)

    Rigidbody2D rb; //このオブジェクトのコンポーネント

    /*オブジェクトを取得する*/
    /*子オブジェクト*/
    [SerializeField] GameObject runObject; //キャラが走る
    [SerializeField] GameObject idleObject; //キャラが待機する
    [SerializeField] GameObject jumpObject; //キャラがジャンプする

    /*子クラスを取得する*/
    [SerializeField] MainCameraManager mainCamera;

    /*他クラスを取得する*/
    //外部オブジェクト関連
    [SerializeField] PlaneManager planeManager;
    [SerializeField] TeleportManager teleObjects;

    //SE関連
    [SerializeField] Se jumpSound;
    [SerializeField] Se stepSound;

    [SerializeField] TeleportManager teleportManager;

    /*クラスは同じだがインスタンスが異なる(テレポート元)*/
    [SerializeField] TeleportObject[] teleObject;　//配列で指定する
   

    [SerializeField] TeleportButton[] teleButton; //配列で指定する

    // Start is called before the first frame update
    void Awake()
    {
        pos = new Vector3(0.0f, 0.0f, 0.0f); //変数を初期化
        isJumping = false; //初期状態はfalse
        isZKey = false; //初期状態はfalse
        isRunStepSound = true; //初期状態はtrue
        touchTeleportObject = -1; //最初はどことも接していないので-1

        //左右に動かしてもよい
        isRightMove = true;
        isLeftMove = true;

        rb = this.gameObject.GetComponent<Rigidbody2D>(); //コンポーネントを取得する
    }

    private void Start()
    {
        runObject.SetActive(false); //走るのを非アクティブ化
        jumpObject.SetActive(false); //ジャンプを非アクティブ化
        idleObject.SetActive(true); //待機をアクティブ化
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
                        teleObject[0].Teleport(this); //テレポートする
                        break;

                    case 1:
                        teleObject[1].Teleport(this); //テレポートする
                        break;

                    case 2:
                        teleObject[2].Teleport(this); //テレポートする
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
        if ((Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))) && (isRightMove))
        {
            if (isJumping)
            {
                idleObject.SetActive(false);
                jumpObject.SetActive(false);
                runObject.SetActive(true);
                if (isRunStepSound)
                {
                    StartCoroutine(RunStepSound());
                }
            }
            else
            {
                //ジャンプをしている最中は待機モーションにならない
            }
            mainCamera.CameraBaseRotation(); //カメラを元の向きに戻す
            Right(); //右側に移動する
        }
        else if ((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow))) && (isLeftMove))
        {
            if (isJumping)
            {
                idleObject.SetActive(false);
                jumpObject.SetActive(false);
                runObject.SetActive(true);
                if (isRunStepSound)
                {    
                    StartCoroutine(RunStepSound());
                }
            }
            else
            {
                //ジャンプをしている最中は待機モーションにならない
            }
            mainCamera.CameraReverseRotation(); //親オブジェクトを反転させたのでカメラを反転させる
            Left(); //左側に移動する
        }
        else
        {
            //待機モーション
            if (isJumping)
            {
                runObject.SetActive(false);
                jumpObject.SetActive(false);
                idleObject.SetActive(true);
            }
            else
            {
                //ジャンプをしている最中は待機モーションにならない
            }

            if (!isRunStepSound)
            {
                StopCoroutine(RunStepSound()); //もし待機モーション時であればRun用のSEを止める
            }

        }
        //垂直キーを取得する
        if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) && (isJumping))
        {
            idleObject.SetActive(false);
            runObject.SetActive(false);
            jumpObject.SetActive(true);
            StartCoroutine(jumpSound.Start_SE());
            Jump(); //ジャンプする
            isJumping = false; //連続でジャンプできないようにする
        }

        /*毎フレーム落下判定する*/
        FallPlayer();
    }

    /*衝突判定*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        //床の衝突判定
        if (planeManager != null)
        {
            //Debug.Log("planes is not null");
            for (int k = 0; k < planeManager.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planeManager.plane[k])
                {
                    isJumping = true;
                    //Debug.Log(k + "番目の床に当たっています");
                    break;
                }
            }
        }
        else
        {
            //たまにnullになるのでnullチェックを入れて回避
            //Debug.Log("planes is null");
        }
    }

    //テレポーターとの接地判定
    private void OnTriggerStay2D(Collider2D collision)
    {
        //nullチェック(nullの場合アクセスするとNullReferenceを返されるので判定しない)
        if (teleObjects != null)
        {
            //どのテレポーターと接しているか
            for (int k = 0; k < teleObjects.childObjectNumbers; k++)
            {
                /*テレポーターと接している場合*/
                if ((collision.gameObject == teleObjects.childObjects[k].gameobject))
                {
                    Debug.Log(k + "番目のテレポーターと接しています");
                    //そのテレポーターが使用可能なら指定された所へテレポートする
                    if (teleObjects.childObjects[k].isTeleport == true)
                    {
                        //接しているテレポーターのテレポート先を取得し、テレポートの許可を与える
                        Debug.Log("接しているテレポーターは使用可能です");
                        isZKey = true; //Zキーを押したら反応するようにする
                        touchTeleportObject = k; //接しているテレポーターに設定する

                        break;
                    }
                    else
                    {
                        Debug.Log("接しているテレポーターは使用できません");
                    }
                }
            }
        }
        else
        {
           
        }
    }

    //テレポーターとの接地が解消された時に呼ばれる
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (touchTeleportObject != -1)
        {
            Debug.Log("テレポーターから離れました");
            isZKey = false; //Zキーを押しても反応しないようにする
            touchTeleportObject = -1; //どことも接していないので
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


    /*指定されたキーによってキャラを動かす*/
    public void Right()
    {
        this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //元の向き（右側に戻す)
        this.pos.x += speed;
        this.transform.position = this.pos; //座標を更新

    }
    public void Left()
    {
        this.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f); //親オブジェクトであるPlayerを反転させる
        this.pos.x -= speed;
        this.transform.position = this.pos; //座標を更新
    }

    public void Jump()
    {
        this.rb.AddForce(jumpForce, ForceMode2D.Impulse); //垂直方法へと力を加える
    }

    public IEnumerator RunStepSound()
    {
        isRunStepSound = false; //再生し終えるまで再生許可は与えない
        yield return StartCoroutine(stepSound.Start_SE());
        yield return new WaitForSeconds(0.3f); //少し補完を入れる
        isRunStepSound = true; //再生し終えたので再度再生許可を与える
    }
}
