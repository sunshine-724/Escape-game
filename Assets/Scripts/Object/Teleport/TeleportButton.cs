using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton :MonoBehaviour
{
    public bool isButton { get;private set; } //ボタンを押したら反応してもよいか

    [SerializeField] Player player;
    [SerializeField] TeleportObject changeTeleportObject; //変更したいオブジェクトを選択する
    [SerializeField] string changeName; //何色に変えたいか指定する

    private void Awake()
    {
        isButton = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //もしプレイヤーと触れたら
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player.gameObject)
        {
            Debug.Log("ボタンに触れました");
            isButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Debug.Log("ボタンから離れました");
            isButton = false;
        }
    }

    //テレポーターの色を変える
    public void ChangeColor()
    {
        changeTeleportObject.ChangeObject(changeName);
    }
}
