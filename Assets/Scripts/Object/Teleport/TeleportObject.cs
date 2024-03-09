using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレハブ化されたテレポートオブジェクトにアタッチする*/
public class TeleportObject :MonoBehaviour
{
    /*親クラスを取得する*/
    [SerializeField] TeleportManager teleportManager;

    /*各子オブジェクト*/
    [SerializeField] GameObject TeleBlackObject;
    [SerializeField] GameObject TeleWhiteObject;

    /*ゲームオブジェクト*/
    [SerializeField] GameObject teleportLocationObject; //テレポート先のオブジェクトを格納する
    // Start is called before the first frame update
    void Start()
    {
        /*設定したタグに沿って最初にアクティブにするオブジェクトをアクティブ化にする*/
        if(this.gameObject.tag == "Black")
        {
            TeleBlackObject.SetActive(true);
        }else if(this.gameObject.tag == "White"){
            TeleWhiteObject.SetActive(true);
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
        for (int k = 0; k < teleportManager.childObjectNumbers; k++)
        {
            if (teleportManager.childObjects[k].gameobject == teleportLocationObject)
            {
                Debug.Log(k + "番目のテレポーターにテレポートします"); //デバッグ
                player.pos.x = teleportManager.childObjects[k].gameobject.transform.position.x;
                player.pos.y = teleportManager.childObjects[k].gameobject.transform.position.y;

                Debug.Log("転送位置は(" + teleportManager.childObjects[k].gameobject.transform.position.x + "," + teleportManager.childObjects[k].gameobject.transform.position.y + ")です");
                player.transform.position = player.pos; //座標を更新(テレポート)
                Debug.Log("テレポート完了");
                break;
            }


            if (k==teleportManager.childObjectNumbers)
            {
                Debug.Log("テレポーター先が設定されていません");
            }
        }
    }
}
