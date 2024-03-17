using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputText : MonoBehaviour
{
    [SerializeField] string password; //パスワードを最初に指定する
    [SerializeField] Text text; //このオブジェクトにあるTextコンポーネントを格納する

    //外部オブジェクトにアタッチされているクラス
    [SerializeField] Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword(); //パスワードがあっているかチェックする
        }else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DeleteNumber(); //末尾を削除する
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            InputNumber("1");
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InputNumber("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InputNumber("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InputNumber("4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            InputNumber("5");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            InputNumber("6");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            InputNumber("7");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            InputNumber("8");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            InputNumber("9");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            InputNumber("0");
        }
    }

    private void OnEnable()
    {
        text.text = "パスワードを入力してください"; //最初の文字列
    }

    private void InputNumber(string stringNumber)
    {
        //もし出力している文が初期文ならば
        if (text.text == "パスワードを入力してください")
        {
            text.text = ""; //文を初期化
        }

        text.text = text.text + stringNumber; //文字を結合して出力する
    }

    private void DeleteNumber()
    {
        //もし出力している文が初期文ならば
        if (text.text == "パスワードを入力してください")
        {
            text.text = ""; //文を初期化
        }
        else
        {
            string newString;
            newString = text.text.Substring(0, (text.text.Length) - 1); //末尾の文字をを削除する
            text.text = newString;
        }
    }

    private void CheckPassword()
    {
        if(password == text.text)
        {
            inventory.GetItem("Key"); //鍵を取得
            this.gameObject.SetActive(false); //このオブジェクトを非アクティブにする
        }
        else
        {
            text.text = "パスワードが正しくありません";
        }
    }
}
