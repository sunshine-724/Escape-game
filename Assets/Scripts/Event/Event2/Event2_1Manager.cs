using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2_1Manager : MonoBehaviour
{
    [SerializeField] Image_Event2 Image2_1_1;
    public bool nowMethod = false; //現在他クラスのコルーチンが実行中であるかどうか
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting1()
    {
        nowMethod = true;
        Image2_1_1.gameObject.SetActive(true);

        //完全に画面が真っ黒になるまで待つ
        while (Image2_1_1.isActive)
        {
            yield return null;
        }
        nowMethod = false;
        isEnd = true;
    }
}
