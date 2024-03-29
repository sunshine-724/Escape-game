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
    //アクション関連
    private bool isTeleport; //テレポートをしても良いか
    private bool isPC; //PCの中身を表示したり、非表示したりしても良いか
    private bool isCoin; //金庫にアクセスしても良いか
    private bool isDoor; //ドアにアクセスしても良いか

    //プレイヤー関連
    private bool isGrounded; //地面と接地しているか
    private bool isJumping; //ジャンプしても良いか
    public bool isRightMove;
    public bool isLeftMove; //イベント1において左方向へ移動はできないようにする(GameManagerのみ書き換え可能)

    private Vector2 stairForce; //段差につまづいた時に垂直方向へと力を加える

    //持ち物関連

    //SE関連
    private bool isRunStepSound; //ステップサウンドが連続して再生されないようにする

    //その他
    private const float fallPositon = -10; //プレイヤーが落下したとみなす座標(調整可能)
    private int touchTeleportObject; //何番目のテレポートオブジェクトと接しているか(していない場合-1を格納)

    private float stairSize; //段差のサイズに応じて垂直に加える力のサイズを変える

    Rigidbody2D rb; //このオブジェクトのコンポーネント

    /*オブジェクトを取得する*/
    /*子オブジェクト*/
    [SerializeField] GameObject runObject; //キャラが走る
    [SerializeField] GameObject idleObject; //キャラが待機する
    [SerializeField] GameObject jumpObject; //キャラがジャンプする

    [SerializeField] Inventory inventory; //インベントリ
    /*子クラスを取得する*/
    [SerializeField] MainCameraManager mainCamera;

    /*他クラスを取得する*/
    //地面を管理
    [SerializeField] PlaneManager planeManager;

    //SE関連
    [SerializeField] Se jumpSound;
    [SerializeField] Se stepSound;


    /*クラスは同じだがインスタンスが異なる(オブジェクト)*/
    [SerializeField] TeleportObject[] teleObject;　//配列で指定する
    [SerializeField] TeleportButton[] teleButton; //配列で指定する

    [SerializeField] GameObject stairManager; //親オブジェクト
    [SerializeField] Stair[] stair; //各階段の段差;

    /*各イベントのオブジェクト*/
    [SerializeField] List<InputEventObject> inputEventObject; //クリックすると特定の画面が開くオブジェクト
    [SerializeField] PC pc; //イベント4で使用するPC
    [SerializeField] Coin coin; //イベント4で使用するコイン
    [SerializeField] Door door; //イベント4で使用するドア

    // Start is called before the first frame update
    void Awake()
    {
        //プレイヤー関連
        pos = new Vector3(0.0f, 0.0f, 0.0f); //変数を初期化
        isGrounded = true; //初期状態はtrue
        isJumping = false; //初期状態はfalse
        isTeleport = false; //初期状態はfalse
        isRunStepSound = true; //初期状態はtrue

        //アクション関連
        isPC = false;
        isCoin = false;
        isDoor = false;
        
        touchTeleportObject = -1; //最初はどことも接していないので-1

        IsMove(true); //初期状態ではtrue

        rb = this.gameObject.GetComponent<Rigidbody2D>(); //コンポーネントを取得する

        if(stairManager != null)
        {
            stairSize = stairManager.transform.localScale.x; //段差のサイズを取得
            stairForce = new Vector2(0.0f, (10.0f) * stairSize); //サイズによって大きさを変える
        }
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

        //もしZキーが押されたら
        if (Input.GetKeyDown(KeyCode.Z))
        {
            /*テレポーター関係*/
            if (isTeleport == true)
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
                isTeleport = false; //一度無効化する
            }

            /*テレポーターの色を変更するボタン関連*/
            for(int k = 0; k < teleButton.Length; k++)
            {
                //特定のボタンと接した状態でZキーを押すと
                if(teleButton[k].isButton == true)
                {
                    teleButton[k].ChangeColor(); //予め指定した色に変える
                } 
            }

            /*InputEventObject関連*/
            for(int k = 0; k < inputEventObject.Count; k++)
            {
                inputEventObject[k].ZKeyNotification();
            }

            /*PC関連*/
            if (isPC)
            {
                if (pc.pc_Power.gameObject.activeSelf)
                {
                    IsMove(true); //再度プレイヤーを動けるようにする
                    pc.checkStatus(); //pcを閉じる
                }
                else
                {
                    IsMove(false); //プレイヤーを動けないようにする
                    pc.checkStatus(); //pcを開ける
                }
            }

            /*金庫関連*/
            if (isCoin)
            {
                if(coin.coinPassword.gameObject.activeSelf)
                {
                    IsMove(true); //再度プレイヤーを動けるようにする
                    coin.checkStatus(); //パスワード画面を閉じる
                }else if ((!coin.coinPassword.gameObject.activeSelf) && (!inventory.CheckInventory("Key")))
                {
                    IsMove(false); //プレイヤーを動けないようにする
                    coin.checkStatus(); //パスワード画面を開ける
                }
            }

            /*ドア関連*/
            if (isDoor)
            {
                door.OpenTheDoor();
            }
        }

        /*キーを取得する*/
        //水平キーを取得する
        if ((Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow))) && (isRightMove))
        {
            if (isGrounded)
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
                //空中にいる際は待機モーションにならない
            }
            mainCamera.CameraBaseRotation(); //カメラを元の向きに戻す
            Right(); //右側に移動する
        }
        else if ((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow))) && (isLeftMove))
        {
            if (isGrounded)
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
                //空中にいる際は待機モーションにならない
            }
            mainCamera.CameraReverseRotation(); //親オブジェクトを反転させたのでカメラを反転させる
            Left(); //左側に移動する
        }
        else
        {
            //待機モーション
            if (isGrounded)
            {
                runObject.SetActive(false);
                jumpObject.SetActive(false);
                idleObject.SetActive(true);
            }
            else
            {
                //空中にいる際は待機モーションにならない
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //階段の段差の衝突判定
        for(int k = 0; k < stair.Length; k++)
        {
            if (collision.gameObject == stair[k].gameObject)
            {
                this.rb.AddForce(stairForce, ForceMode2D.Impulse); //垂直方法へと力を加える
                Debug.Log("実行中");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //床の衝突判定
        if (planeManager != null)
        {
            for (int k = 0; k < planeManager.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planeManager.plane[k])
                {
                    isGrounded = true; //地面に接地しているのでtrue

                    //その床がジャンプを可能としているかタグでチェック
                    if(collision.gameObject.tag == "isJump")
                    {
                        isJumping = true;
                    }
                    break; //地面は一つしか接しないのでこれ以上検索をかける必要がない
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //床の衝突判定
        if (planeManager != null)
        {
            for (int k = 0; k < planeManager.childPlaneNumbers; k++)
            {
                if (collision.gameObject == planeManager.plane[k])
                {
                    isGrounded = false; //地面から離れたのでfalse
                    break;  //地面は一つしか接しないのでこれ以上検索をかける必要がない
                }
            }
        }
    }

    //トリガー判定
    private void OnTriggerStay2D(Collider2D collision)
    {
        //全部のテレポーターに関して検索をかける
        for(int k = 0; k < teleObject.Length; k++)
        {
            if(collision.gameObject == teleObject[k].gameObject)
            {
                Debug.Log(k + "番目のテレポーターと接しています");

                if (teleObject[k].isTeleport)
                {
                    //接しているテレポーターのテレポート先を取得し、テレポートの許可を与える
                    Debug.Log("接しているテレポーターは使用可能です");
                    isTeleport = true; //Zキーを押したら反応するようにする
                    touchTeleportObject = k; //接しているテレポーターに設定する
                    break;
                }
                else
                {
                    Debug.Log("接しているテレポーターは使用できません");
                }
            }
        }

        //もしテレポーターの色を変更するボタンに触れていたら
        for(int k = 0; k < teleButton.Length; k++)
        {
            if(collision.gameObject == teleButton[k].gameObject)
            {
                Debug.Log(k + "番目のボタンと接してます");
            }
        }

        //もしPCを接触していたら
        if((pc != null) && collision.gameObject == pc.gameObject)
        {
            isPC = true; //Zキーを押すとPCの中身が表示させるようにする
        }

        //もし金庫と接触していたら
        if((coin != null) && collision.gameObject == coin.gameObject)
        {
            isCoin = true; //Zキーを押すと金庫にアクセスできるようにする
        }

        //もしドアと接触していたら
        if((door != null) && collision.gameObject == door.gameObject)
        {
            isDoor = true; //Zキーを押すとドアにアクセスできるようにする
        }
    }

    //テレポーターとの接地が解消された時に呼ばれる
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (touchTeleportObject != -1)
        {
            Debug.Log("テレポーターから離れました");
            isTeleport = false; //Zキーを押しても反応しないようにする
            touchTeleportObject = -1; //どことも接していないので
        }else if((pc !=null) &&(collision.gameObject == pc.gameObject))
        {
            isPC = false; //PCから離れるので中身を見る許可をなくす
        }else if((coin != null) && (collision.gameObject == coin.gameObject))
        {
            isCoin = false; //金庫にアクセスできないようにする
        }else if((door != null) &&(collision.gameObject == door.gameObject))
        {
            isDoor = false; //ドアにアクセスできないようにする
        }
        else
        {
           
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

    //引数によってプレイヤーの動きを制御できる
    public void IsMove(bool status)
    {
        if (status)
        {
            isRightMove = true;
            isLeftMove = true;
        }
        else
        {
            isRightMove = false;
            isLeftMove = false;
        }
    }

    public IEnumerator RunStepSound()
    {
        isRunStepSound = false; //再生し終えるまで再生許可は与えない
        yield return StartCoroutine(stepSound.Start_SE());
        yield return new WaitForSeconds(0.3f); //少し補完を入れる
        isRunStepSound = true; //再生し終えたので再度再生許可を与える
    }
}
