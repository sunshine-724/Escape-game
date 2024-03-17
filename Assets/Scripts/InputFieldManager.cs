using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] string password; //パスワードを最初に指定する
    [SerializeField] InputField inputField; //InputFieldコンポーネントを格納する
    [SerializeField] Text text; //InputFieldオブジェクトの子オブジェクトにあるTextコンポーネントを格納する

    //外部オブジェクトにアタッチされているクラス
    [SerializeField] Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if ((!inputField) && (password != null))
        {
            inputField.text = ""; //出力している文字列を初期化する
        }
    }

    //数字を入力したり、文字を入力するとこのメソッドが起動する
    public void GetInputNumber()
    {
        text.text = inputField.text; //テキストを代入
        Debug.Log("代入しています");
    }

    //入力終了時、事前に設定したパスワードと等しいかチェックする
    public void CheckInputNumber()
    {
        if(password == text.text)
        {
            inventory.GetItem("Key"); //アイテムを追加する
        }
    }
}
