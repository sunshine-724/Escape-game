using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音楽を再生したいときはアタッチしたオブジェクトをアクティブにし、メソッドを実行する
public class SoundBoxScript : MonoBehaviour
{
    [SerializeField] Se sound; //音楽を指定するクラス
    [SerializeField] int repeatNumber; //リピートする回数を指定させる（指定がない場合、鳴らすのは1回）

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        //指定されていない場合
        if(repeatNumber == 0)
        {
            repeatNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アクティブになったら音を鳴らす
    private void OnEnable()
    {
        StartCoroutine(StartMusic());
    }

    //非アクティブになったら音を鳴らすのをやめる
    private void OnDisable()
    {
        StopCoroutine(StartMusic()); 
    }

    //指定した回数分、音を鳴らし終わるまでまつ
    private IEnumerator StartMusic()
    {
        for (int k = 0; k <= repeatNumber; k++)
        {
            yield return StartCoroutine(sound.Start_SE());
            Debug.Log(k+"回鳴らしました");
        }
    }
    
}
