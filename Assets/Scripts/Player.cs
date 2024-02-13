using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*変数宣言*/
    //キャラ関係
    public bool isMove = false; //プレイヤーが動いていいか良くないかのフラグ
    public bool isRunning = false; //走って良いかを表すフラグ
    public bool isJumping = false; //ジャンプしていいかのフラグ
    public Vector3 pos = new Vector3(0.0f,0.0f,0.0f); //プレイヤーの現在の座標

    /*オブジェクトを取得する*/
    [SerializeField] GameObject tileMap;
    //親オブジェクト
    [SerializeField] GameObject playerObject;
    //子オブジェクト
    [SerializeField] GameObject run; //走る画像を取得する
    [SerializeField] GameObject jump; //ジャンプする画像を取得する
    [SerializeField] GameObject idle; //待機の画像を取得する

    /*クラスの参照を取得*/
    CharacterMove move; //キャラを制御するクラスの参照先
    MainCamera mainCamera; //メインカメラを制御するクラスの参照先
    

    //コンストラクタ
    public Player()
    {
        move = new CharacterMove();
    }

    // Start is called before the first frame update
    void Start()
    {
        isMove = true; //動かしても良い
        isRunning = true; //走っても良い
        run.SetActive(false); //走るのを非アクティブ化
        jump.SetActive(false); //ジャンプを非アクティブ化
        idle.SetActive(true); //待機をアクティブ化
        pos = this.transform.position; //変数を初期化
    }

    // Update is called once per frame
    void Update()
    {
        /*プレイヤーの現在の座標を取得する*/
        pos = transform.position;

        /*キーを取得する*/
        //水平キーを取得する
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            idle.SetActive(false);
            jump.SetActive(false);
            run.SetActive(true);
            move.Right(); //右に動かす
        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            idle.SetActive(false);
            jump.SetActive(false);
            run.SetActive(true);
            move.Left(); //左に動かす
        }
        else
        {
            //待機モーション
            run.SetActive(false);
            jump.SetActive(false);
            idle.SetActive(true);
        }

        //垂直キーを取得する
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (isJumping))
        {
            idle.SetActive(false);
            run.SetActive(false);
            jump.SetActive(true);
            move.Jump(); //ジャンプする
            isJumping = false; //連続でジャンプできないようにする
        }
    }

    /*衝突判定*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == tileMap)
        {
            isJumping = true; //床についていたらジャンプできるようにする
        }
    }
}
