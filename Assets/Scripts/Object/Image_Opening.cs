using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*image_openingにアタッチする*/
public class Image_Opening : MonoBehaviour
{
    [SerializeField] GameManager gameManager; //ゲームマネージャークラス

    /*変数宣言*/
    float alpha; //出力する透明度
    const float alphaMax = 1.0f; //透明度の最高値
    private bool isFadein = false; //フェードインして良いかどうか(最初はfalse）

    /*親オブジェクト(このオブジェクト)関連*/
    Image thisObjectImage; //imageコンポーネント
    
    /*子オブジェクト関連*/
    Transform childObjectTransform; //子オブジェクトのtransform
    Text childObjectText; //テキストコンポーネント
    
    private void Awake()
    {
        thisObjectImage = this.GetComponent<Image>(); //このオブジェクトのイメージコンポーネントを取得する
       
        /*子オブジェクト関連*/
        childObjectTransform = this.transform.GetChild(0); //子オブジェクトを取得
        if(childObjectTransform != null)
        {
            childObjectText = childObjectTransform.gameObject.GetComponent<Text>(); //子オブジェクトのテキストコンポーネントを取得する
        }else
        {
            Debug.Log("子オブジェクトを取得できませんでした");
        }

        alpha = alphaMax; //初期値
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*イベント1開始時期について*/
        //もしZキーが押されて、イベント開始許可が下りていたら
        if((Input.GetKeyDown(KeyCode.Z)))
        {
            Debug.Log("Zキーが押されました");
            if(gameManager.CheckEvent(1))
            {
                StartEvent1(); //イベント1実行
            }
            else
            {
                Debug.Log("イベント1開始許可が出てません");
            }
            
        }

        ///*フェードインに関して*/
        //if(isFadein == true)
        //{
        //    thisObjectImage.color = new Color(0, 0, 0, alpha);
        //    childObjectText.color = new Color(255, 255, 255, alpha);
        //    alpha--;
        //    if(alpha == 0)
        //    {
        //        Debug.Log("alphaの値は" + alpha + "です");
        //        isFadein = false;
        //    }
        //}
        //else
        //{
        //    Debug.Log("フェードインできません");
        //}
  
    }

    /*イベント1を開始する*/
    private int StartEvent1()
    {
        Debug.Log("デバッグコードが実行されました");

        StartCoroutine(Fade());

        Debug.Log("フェードインが実行されます");
        //isFadein = true;
        //Debug.Log("フェードインが実行されました");

        return 0;
    }

    public IEnumerator Fade()
    {
        for (alpha = alphaMax; alpha >= 0; alpha-=0.01f)
        {
            thisObjectImage.color = new Color(0, 0, 0, alpha);
            childObjectText.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        Debug.Log("Fadeメソッドを実行し終えました");
    }
}
