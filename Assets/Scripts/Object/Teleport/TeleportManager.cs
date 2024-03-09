using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*'TeleportObjects'オブジェクトにアタッチする*/

public class TeleportManager : MonoBehaviour
{
    /*ゲームオブジェクト*/
    [System.NonSerialized] public ChildTeleportObject[] childObjects; //それぞれの子オブジェクトを取得する
                                                                      //同スクリプト内（名前空間が同じ）ならば他クラスの取得は不要

    /*変数宣言*/
    Transform childTransform; //子オブジェクトのtransformコンポーネント
    [System.NonSerialized] public int childObjectNumbers; //子オブジェクトの数(後で検索をかける）

    private void Awake()
    {
        childObjectNumbers = this.transform.childCount; //子オブジェクトの数を取得する

        /*必要な分だけ配列を生成*/
        childObjects = new ChildTeleportObject[childObjectNumbers];
        for (int k = 0; k < childObjectNumbers; k++)
        {
            childObjects[k] = new ChildTeleportObject(); //インスタンスを作成する
            childTransform = this.transform.GetChild(k); //各々の子オブジェクトのtransformを取得
            childObjects[k].gameobject = childTransform.gameObject; //子オブジェクトの参照先を格納する

            /*予め設定したタグで最初にどの色のテレポーターを出現させるか決める(適宜、色を追加する)*/
            if (childObjects[k].gameobject.tag == "Black")
            {
                childObjects[k].isColor = ChildTeleportObject.Color.BLACK;
                Debug.Log("タグはBlackです");
            }
            else if (childObjects[k].gameobject.tag == "White")
            {
                childObjects[k].isColor = ChildTeleportObject.Color.WHITE;
                Debug.Log("タグはWhiteです");
            }
            else
            {
                Debug.Log("存在しないタグです");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class ChildTeleportObject: MonoBehaviour
{
    //各テレポーターの色の種類(後で増やすかも)
    //enum 定数を構造体形式で保存可能 呼び出す際はColor.Blackなどで呼び出す　またそれぞれ0,1,…で識別できる
    public enum Color
    {
        BLACK,
        WHITE,
    }

    public GameObject gameobject; //テレポーター自身
    public Color isColor; //オブジェクト自身が今何色のテレポーターをしているか（アクティブか）
    public bool isTeleport; //テレポートを使えるかどうか

    /*コンストラクタ*/
    public ChildTeleportObject()
    {
        isTeleport = false; //最初は全てfalseにする;
        isTeleport = true; //デバッグ
    }

    /*enumの要素数を取得する*/
    public static int GetColorNumber()
    {
        int number; //テレポーターの色の数
        number = Enum.GetValues(typeof(Color)).Length; //色の数を取得する
        return number;
    }
}
