using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*'TeleportObjects'オブジェクトにアタッチする*/
public class TeleportObjects : MonoBehaviour
{
    //各テレポーターの色の種類(後で増やすかも)
    //enum 定数を構造体形式で保存可能 呼び出す際はColor.Blackなどで呼び出す　またそれぞれ0,1,…で識別できる
    public enum Color
    {
        BLACK,
        WHITE,
    }

    /*オブジェクトを取得する(インスペクターで)*/
    [SerializeField] GameObject tele0;
    [SerializeField] GameObject tele1;
    [SerializeField] GameObject tele2;

    /*変数宣言*/
    [SerializeField] const int teleportObjectsNumber = 3; //生成するテレポーターの数
    [SerializeField] Color[] colorList; //テレポーターをどの色にするかインスペクターで指定できる配列

    // Start is called before the first frame update
    void Start()
    {
        colorList = new Color[teleportObjectsNumber]; //配列をインスタンス化

        



        //teleportObjects = new TeleportObject[teleportObjectsNumber]; //指定したオブジェクトの数の配列を確保する

        //for (int k = 0; k < teleportObjectsNumber; k++)
        //{
        //    teleportObjects[k] = new TeleportObject(); //配列を初期化
        //}

        //if (tele0 = null)
        //{
        //    Debug.Log("オブジェクトが正しく参照されていません");
        //}
        //Debug.Log("テレポートオブジェクトを生成しました");

        ///*オブジェクトの参照を可能にする(ここはもうちょっと改善の余地あり)*/
        //teleportObjects[0].teleportObject = tele0;
        //teleportObjects[1].teleportObject = tele1;
        //teleportObjects[2].teleportObject = tele2;

        ///*もし必要ならここに各テレポーターの初期情報データのメソッドをここに入れる*/
        //for (int k = 0; k < teleportObjectsNumber; k++)
        //{
        //    if (teleportObjects[k].tag == "Black")
        //    {
        //        teleportObjects[k].isColor = Color.BLACK;
        //        Debug.Log("色を黒にします");
        //    }
        //    else if (teleportObjects[k].tag == "White")
        //    {
        //        teleportObjects[k].isColor = Color.WHITE;
        //        Debug.Log("色を白にします");
        //    }
        //    else
        //    {
        //        Debug.Log(k + "番目のタグで色が指定されていないので指定してください");
        //        /*また色を追加するかもしれない*/
        //    }

        //    Debug.Log("デバッグ");
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}