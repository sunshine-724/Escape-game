using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*'Planes'にアタッチするスクリプト*/

public class Planes : MonoBehaviour
{
    /*ゲームオブジェクト*/
    [SerializeField] Transform parentPlanes; //親オブジェクトのtransformコンポーネントを取得する
    public GameObject[] plane; //個々の子オブジェクトを全て格納した配列

    /*変数宣言*/
    public int childPlaneNumber; //地面の数
    private Transform childTransform;  //子オブジェクトのtransformコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        childPlaneNumber = parentPlanes.transform.childCount; //子オブジェクトの数を取得する
        plane = new GameObject[childPlaneNumber];

        Debug.Log("子オブジェクトの数は" + childPlaneNumber + "です");

        /*必要な分だけ子オブジェクトを取得する*/
        for (int k = 0; k < childPlaneNumber; k++)
        {
            childTransform = parentPlanes.transform.GetChild(k); //子オブジェクトのtransformコンポーネントを取得する
            plane[k] = childTransform.gameObject; //子オブジェクトを順番に取得する
            Debug.Log(k + "番目のPlaneを取得しました");

            if (plane[k].GetComponent<BoxCollider2D>())
            {
                Debug.Log("Rigidbody2D含まれてるよ");
            }
            else
            {
                Debug.Log("Rigidbody2D含まれてないよ");
                gameObject.AddComponent<Rigidbody2D>(); // 含まれてなければ加える
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
