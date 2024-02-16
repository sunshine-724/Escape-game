using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*プレイヤーオブジェクトにアタッチする*/
public class CharacterMove : Player
{
    public Vector2 jumpForce = new Vector2(0.0f, 7.0f); //ジャンプの強さ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }




    /*指定されたキーによってキャラを動かす*/
    public void Right(Player player)
    {
        player.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f); //元の向き（右側に戻す)
        player.pos.x += 0.02f;
        player.transform.position = player.pos; //座標を更新

    }
    public void Left(Player player)
    {
        player.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f); //親オブジェクトであるPlayerを反転させる
        player.pos.x -= 0.02f;
        player.transform.position = player.pos; //座標を更新
    }

    public void Jump(Player player)
    {
        Rigidbody2D rb = player.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(jumpForce, ForceMode2D.Impulse); //垂直方法へと力を加える
    }


}
