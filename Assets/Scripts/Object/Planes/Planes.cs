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
    public int childPlaneNumbers; //地面の数
    private Transform childTransform;  //子オブジェクトのtransformコンポーネント

    private void Awake()
    {
        childPlaneNumbers = parentPlanes.transform.childCount; //子オブジェクトの数を取得する
        plane = new GameObject[childPlaneNumbers];

        Debug.Log("子オブジェクトの数は" + childPlaneNumbers + "です");

        /*必要な分だけ子オブジェクトを取得する*/
        for (int k = 0; k < childPlaneNumbers; k++)
        {
            childTransform = parentPlanes.transform.GetChild(k); //子オブジェクトのtransformコンポーネントを取得する
            plane[k] = childTransform.gameObject; //子オブジェクトを順番に取得する
            Debug.Log(k + "番目のPlaneを取得しました");
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
