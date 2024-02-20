using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*テキストを出したいオブジェクトにアタッチする*/
public class Appeartext : MonoBehaviour
{
    /*他クラスの取得*/
    [SerializeField] Se sound; //文字を出力する時に音を出したいときはクラスの参照先を指定する

    /*変数宣言*/
    [SerializeField] string str; //配列で出力したい文字列を管理する
    [SerializeField] float textSpeed; //テキストを出力するスピードを決める(s) (0.05推薦)
    Text textComponent;
    string outputStr; //実際出力する文字配列(毎回初期化される)
    int strNumber; //文字列の要素数


    //初期化
    private void Awake()
    {
        str = str + " "; //ヌル文字を追加
        textComponent = this.GetComponent<Text>(); //textコンポーネントを取得

        strNumber = str.Length; //要素数を取得する
        Debug.Log("文字列の要素数は" + strNumber + "です");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*最初にテキストを出現させるところ*/
    public IEnumerator AppearText()
    {
        for (int j = 0; j < strNumber; j++)
        {
            outputStr = str.Substring(0, j);
            textComponent.text = outputStr;
            // Nullチェック
            if (sound == null)
            {
                Debug.Log("soundが設定されていません");
            }
            else
            {
                sound.Typing();
            }
            yield return new WaitForSeconds(textSpeed); //指定した秒数だけ遅れる
        }

        Debug.Log("テキストの出力が完了しました");
    }
}
