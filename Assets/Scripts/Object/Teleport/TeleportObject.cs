using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレハブ化されたテレポートオブジェクトにアタッチする*/
public class TeleportObject :MonoBehaviour
{
    /*親クラスを取得する*/
    [SerializeField] TeleportObjects teleportObjectClass;

    /*ゲームオブジェクト*/
    [SerializeField] GameObject teleportPairObject; //テレポート先のオブジェクトを格納する
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*特定の条件下でキー操作をしてテレポートを使用可能にする*/
    public void Teleport(Player player)
    {
        for (int k = 0; k < teleportObjectClass.childObjectNumbers; k++)
        {
            if (teleportObjectClass.childObjects[k].gameobject == teleportPairObject)
            {
                Debug.Log(k + "番目のテレポーターにテレポートします"); //デバッグ
                player.pos.x = teleportObjectClass.childObjects[k].gameobject.transform.position.x;
                player.pos.y = teleportObjectClass.childObjects[k].gameobject.transform.position.y;

                /*転送位置をちょっと調整(誤差分)*/
                player.pos.x -= 1.0f;
                player.pos.y -= 1.5f;

                Debug.Log("転送位置は(" + teleportObjectClass.childObjects[k].gameobject.transform.position.x + "," + teleportObjectClass.childObjects[k].gameobject.transform.position.y + ")です");
                player.transform.position = player.pos; //座標を更新(テレポート)
                Debug.Log("テレポート完了");
                break;
            }


            if (k==teleportObjectClass.childObjectNumbers)
            {
                Debug.Log("テレポーター先が設定されていません");
            }
        }
    }
}
