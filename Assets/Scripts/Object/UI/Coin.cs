using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*金庫に関するクラス*/
public class Coin : MonoBehaviour
{
    public GameObject coinPassword; //UI
    [SerializeField] InputText inputText; //入力したものを出力するテキスト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*金庫と接触していてかつZキーを押されたらオブジェクトの状態によってメソッドを実行する*/
    public void checkStatus()
    {
        //PCの中身を映す特定のゲームオブジェクトがアクティブか非アクティブかによって挙動を変える
        if (!coinPassword.activeSelf)
        {
            AppearPassword(); //起動
        }
        else
        {
            DisappearPassword(); //停止
        }
    }

    private void AppearPassword()
    {
        coinPassword.SetActive(true);
    }

    private void DisappearPassword()
    {
        coinPassword.SetActive(false);
    }
}
