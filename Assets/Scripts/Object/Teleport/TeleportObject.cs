using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレハブ化されたテレポートオブジェクトにアタッチする*/
public class TeleportObject :MonoBehaviour
{
    /*各子オブジェクト*/
    [SerializeField] GameObject TeleBlackObject;
    [SerializeField] GameObject TeleWhiteObject;

    public enum Color
    {
        BLACK = 0,
        WHITE = 1,
    }

    /*テレポート先*/
    [SerializeField] TeleportObject[] teleportLocationObject; //各色に対して、テレポート先のオブジェクトを格納する

    /*変数宣言*/
    [SerializeField] int ObjectNumber; //各テレポーターを区別するための番号
    public int isColor { get; private set; } //今このテレポーターがどの色をしているか
    public bool isTeleport { get; private set; } //テレポートを使えるかどうか


    private void Awake()
    {

        isTeleport = true; //最初は全部のテレポータを使用可能にする
    }

    // Start is called before the first frame update
    void Start()
    {
        /*設定したタグに沿って最初にアクティブにするオブジェクトをアクティブ化にする*/
        if(this.gameObject.tag == "Black")
        {
            ChangeObject("Black");
        }else if(this.gameObject.tag == "White"){
            ChangeObject("White");
        }
        else
        {
            Debug.Log("存在しないタグです");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*特定の条件下でキー操作をしてテレポートを使用可能にする*/
    public void Teleport(Player player)
    {
        if(teleportLocationObject[isColor] != null)
        {
            player.pos.x = teleportLocationObject[isColor].transform.position.x;
            player.pos.y = teleportLocationObject[isColor].transform.position.y;

            Debug.Log("転送位置は" + player.pos.x + "," + player.pos.y + "です");
            player.transform.position = player.pos;
            Debug.Log("テレポート完了");
        }
        else
        {
            Debug.Log("テレポーター先が設定されていません");
        }
    }

    //指定された色に変える
    public void ChangeObject(string colorName)
    {
        if(colorName == "Black")
        {
            TeleBlackObject.SetActive(true);
            TeleWhiteObject.SetActive(false);

            isColor = (int)Color.BLACK;
        }
        else if(colorName == "White")
        {
            TeleWhiteObject.SetActive(true);
            TeleBlackObject.SetActive(false);

            isColor = (int)Color.WHITE;
        }
        else
        {
            Debug.Log("その色は存在しません");
        }
    }
}
