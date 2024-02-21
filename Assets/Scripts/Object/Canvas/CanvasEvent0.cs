using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEvent0 : MonoBehaviour
{

    [SerializeField] Image_Opening image_Opening; //image_Openingクラスを取得する
    [SerializeField] Text_Opening text_Opening;
    private bool isFadein =false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(text_Opening.Opening());
        StartCoroutine(EndText_Opening());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isFadein)
            {
                Debug.Log("fadeメソッド開始");
                StartCoroutine(image_Opening.Fade()); //フェードインさせる
            }
        }
    }

    private IEnumerator EndText_Opening()
    {
        yield return StartCoroutine(text_Opening.Opening()); //テキストを全部出力するまで待つ
        isFadein = true; //フェードインする許可を与える
    }
}
