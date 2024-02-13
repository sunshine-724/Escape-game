using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    Player player; //Playerクラスの参照先
    MainCamera mainCamera; //MainCameraクラスの参照先

    public Vector2 jump = new Vector2 (0,5); //ジャンプの強さ(適宜調整)

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*コンストラクタ*/
    public CharacterMove()
    {
        player = new Player(); //インスタンスを設定
    }

    /*指定したキーによってキャラを動かす*/
    public void Right()
    {
        player.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //元の向き（右側に戻す)
        player.pos.x += 0.02f;
        player.transform.position = player.pos; //座標を更新

    }
    public void Left()
    {
        player.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f); //反転させる
        player.pos.x -= 0.02f;
        player.transform.position = player.pos; //座標を更新
    }

    public void Jump()
    {
        Rigidbody2D rb = player.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(jump,ForceMode2D.Impulse); //垂直方法へと力を加える
    }
    //public void Jump()
    //{
    //    player.pos.y += 3.0f;
    //    player.transform.position = player.pos; //座標を更新   
    //}
}
